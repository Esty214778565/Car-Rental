from datetime import datetime, timedelta
from fastapi.testclient import TestClient
import pytest

from vessel_service.main import app
from vessel_service import storage


client = TestClient(app)


@pytest.fixture(autouse=True)
def reset_storage():
    """Reset storage before each test."""
    storage.seed_data()
    yield


def test_list_vessels():
    """Test listing vessels."""
    response = client.get("/vessels/")
    assert response.status_code == 200
    vessels = response.json()
    assert len(vessels) == 10
    assert all("id" in v and "name" in v for v in vessels)


def test_get_vessel():
    """Test getting a specific vessel."""
    # Get first vessel from storage
    vessel_id = storage.VESSELS[0].id
    
    response = client.get(f"/vessels/{vessel_id}")
    assert response.status_code == 200
    vessel = response.json()
    assert vessel["id"] == vessel_id


def test_create_vessel():
    """Test creating a new vessel."""
    response = client.post("/vessels/", json={"name": "New Test Vessel"})
    assert response.status_code == 201
    vessel = response.json()
    assert vessel["name"] == "New Test Vessel"
    assert vessel["id"].startswith("v")


def test_vessel_activities():
    """Test getting activities for a vessel."""
    # Get first vessel from storage
    vessel_id = storage.VESSELS[0].id
    
    response = client.get(f"/vessels/{vessel_id}/activities")
    assert response.status_code == 200
    activities = response.json()
    assert all(a["vessel_id"] == vessel_id for a in activities)


def test_overlapping_activities():
    """Test getting activities that overlap with a time range."""
    # Create a time range in the middle of July 2025
    start = datetime(2025, 7, 10)
    end = datetime(2025, 7, 20)
    
    response = client.post(
        "/activities/overlapping",
        json={
            "start": start.isoformat(),
            "end": end.isoformat()
        }
    )
    assert response.status_code == 200
    activities = response.json()
    
    # Verify that all returned activities overlap with the range
    for activity in activities:
        activity_start = datetime.fromisoformat(activity["start"])
        activity_end = datetime.fromisoformat(activity["end"])
        
        # Check if activity overlaps with the range
        assert activity_start < end and activity_end > start


def test_activities_within_range():
    """Test getting activities that are completely within a time range."""
    # Create a time range covering all of July 2025
    start = datetime(2025, 7, 1)
    end = datetime(2025, 7, 31)
    
    response = client.post(
        "/activities/within",
        json={
            "start": start.isoformat(),
            "end": end.isoformat()
        }
    )
    assert response.status_code == 200
    activities = response.json()
    
    # Verify that all returned activities are within the range
    for activity in activities:
        activity_start = datetime.fromisoformat(activity["start"])
        activity_end = datetime.fromisoformat(activity["end"])
        
        # Check if activity is within the range
        assert activity_start >= start and activity_end <= end


def test_activities_after():
    """Test getting activities that start after a given time."""
    # Get activities after July 15, 2025
    start = datetime(2025, 7, 15)
    
    response = client.post(
        "/activities/after",
        json={
            "start": start.isoformat()
        }
    )
    assert response.status_code == 200
    activities = response.json()
    
    # Verify that all returned activities start after the given time
    for activity in activities:
        activity_start = datetime.fromisoformat(activity["start"])
        assert activity_start >= start


def test_activities_before():
    """Test getting activities that end before a given time."""
    # Get activities that end before July 15, 2025
    end = datetime(2025, 7, 15)
    
    response = client.post(
        "/activities/before",
        json={
            "end": end.isoformat()
        }
    )
    assert response.status_code == 200
    activities = response.json()
    
    # Verify that all returned activities end before the given time
    for activity in activities:
        activity_end = datetime.fromisoformat(activity["end"])
        assert activity_end <= end


def test_activities_covering_range():
    """Test getting activities that completely cover a time range."""
    # Create a narrow time range
    start = datetime(2025, 7, 10)
    end = datetime(2025, 7, 12)
    
    response = client.post(
        "/activities/covering",
        json={
            "start": start.isoformat(),
            "end": end.isoformat()
        }
    )
    assert response.status_code == 200
    activities = response.json()
    
    # Verify that all returned activities cover the range
    for activity in activities:
        activity_start = datetime.fromisoformat(activity["start"])
        activity_end = datetime.fromisoformat(activity["end"])
        
        # Check if activity covers the range
        assert activity_start <= start and activity_end >= end


def test_filter_by_vessel_ids_and_types():
    """Test filtering activities by vessel IDs and activity types."""
    # Get first two vessel IDs
    vessel_ids = [v.id for v in storage.VESSELS[:2]]
    
    response = client.post(
        "/activities/overlapping",
        json={
            "vessel_ids": vessel_ids,
            "types": ["port call", "bunkering"]
        }
    )
    assert response.status_code == 200
    activities = response.json()
    
    # Verify that all returned activities match the filters
    for activity in activities:
        assert activity["vessel_id"] in vessel_ids
        assert activity["type"] in ["port call", "bunkering"]
