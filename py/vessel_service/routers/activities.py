from typing import List
from fastapi import APIRouter, HTTPException, Path, Body, Query
from datetime import datetime

from vessel_service import storage
from vessel_service.models import Activity, ActivityCreate, RangeFilter

router = APIRouter(
    prefix="/activities",
    tags=["activities"],
    responses={404: {"description": "Activity not found"}},
)


@router.get("/", response_model=List[Activity])
async def list_all_activities():
    """
    Get all activities in the system.
    """
    return storage.ACTIVITIES


@router.post("/", response_model=Activity, status_code=201)
async def create_activity(activity: ActivityCreate = Body(...)):
    """
    Create a new activity.
    """
    # Validate that the vessel exists
    vessel = storage.get_vessel(activity.vessel_id)
    if not vessel:
        raise HTTPException(status_code=404, detail=f"Vessel {activity.vessel_id} not found")

    # Validate that start is before end
    if activity.start >= activity.end:
        raise HTTPException(status_code=400, detail="Activity start time must be before end time")
    print("check if printing works")
    return storage.create_activity(
        vessel_id=activity.vessel_id,
        type_=activity.type,
        start=activity.start,
        end=activity.end
    )


@router.delete("/{activity_id}", status_code=204)
async def delete_activity(activity_id: str = Path(..., description="ID of the activity to delete")):
    """
    Delete an activity.
    """
    success = storage.delete_activity(activity_id)
    if not success:
        raise HTTPException(status_code=404, detail=f"Activity {activity_id} not found")
    return None


@router.post("/overlapping", response_model=List[Activity])
async def get_overlapping_activities(filter: RangeFilter = Body(...)):
    """
    Get activities that overlap with the given time range.
    
    An activity overlaps if:
    - Its start time is before the filter's end time AND
    - Its end time is after the filter's start time
    """
    rule = lambda activity, start, end: (
        (start is None or activity.end > start) and 
        (end is None or activity.start < end)
    )
    
    return storage.query_activities(
        rule=rule,
        vessel_ids=filter.vessel_ids,
        types=filter.types,
        start=filter.start,
        end=filter.end
    )


@router.post("/within", response_model=List[Activity])
async def get_activities_within_range(filter: RangeFilter = Body(...)):
    """
    Get activities that are completely within the given time range.
    
    An activity is within if:
    - Its start time is >= the filter's start time AND
    - Its end time is <= the filter's end time
    """
    rule = lambda activity, start, end: (
        (start is None or activity.start >= start) and 
        (end is None or activity.end <= end)
    )
    
    return storage.query_activities(
        rule=rule,
        vessel_ids=filter.vessel_ids,
        types=filter.types,
        start=filter.start,
        end=filter.end
    )


@router.post("/after", response_model=List[Activity])
async def get_activities_after(filter: RangeFilter = Body(...)):
    """
    Get activities that start after the given start time.
    
    An activity is after if:
    - Its start time is >= the filter's start time
    - The filter's end time is ignored
    """
    rule = lambda activity, start, _: start is None or activity.start >= start
    
    return storage.query_activities(
        rule=rule,
        vessel_ids=filter.vessel_ids,
        types=filter.types,
        start=filter.start,
        end=None  # Explicitly ignore end time
    )


@router.post("/before", response_model=List[Activity])
async def get_activities_before(filter: RangeFilter = Body(...)):
    """
    Get activities that end before the given end time.
    
    An activity is before if:
    - Its end time is <= the filter's end time
    - The filter's start time is ignored
    """
    rule = lambda activity, _, end: end is None or activity.end <= end
    
    return storage.query_activities(
        rule=rule,
        vessel_ids=filter.vessel_ids,
        types=filter.types,
        start=None,  # Explicitly ignore start time
        end=filter.end
    )


@router.post("/covering", response_model=List[Activity])
async def get_activities_covering_range(filter: RangeFilter = Body(...)):
    """
    Get activities that completely cover the given time range.
    
    An activity covers the range if:
    - Its start time is <= the filter's start time AND
    - Its end time is >= the filter's end time
    """
    rule = lambda activity, start, end: (
        (start is None or activity.start <= start) and 
        (end is None or activity.end >= end)
    )
    
    return storage.query_activities(
        rule=rule,
        vessel_ids=filter.vessel_ids,
        types=filter.types,
        start=filter.start,
        end=filter.end
    )
