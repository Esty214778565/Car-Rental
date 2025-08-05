import random
import uuid
from datetime import datetime, timedelta
from typing import List, Optional, Callable

from vessel_service.models import Vessel, Activity, ActivityType, RangeFilter


# In-memory storage for vessels and activities
VESSELS: List[Vessel] = []
ACTIVITIES: List[Activity] = []


def _random_datetime(start_date: datetime = None, end_date: datetime = None) -> datetime:
    """Generate a random datetime between start_date and end_date."""
    if not start_date:
        start_date = datetime(2025, 7, 1)
    if not end_date:
        end_date = datetime(2025, 7, 31)
    
    delta = end_date - start_date
    random_seconds = random.randint(0, int(delta.total_seconds()))
    return start_date + timedelta(seconds=random_seconds)


def _random_activity_period() -> tuple[datetime, datetime]:
    """Generate a random start and end datetime for an activity."""
    start = _random_datetime()
    # Activity duration between 2 hours and 3 days
    duration_hours = random.randint(2, 72)
    end = start + timedelta(hours=duration_hours)
    return start, end


def seed_data():
    """Seed the in-memory storage with 10 vessels and 20 activities."""
    global VESSELS, ACTIVITIES
    
    # Clear existing data
    VESSELS = []
    ACTIVITIES = []
    
    # Create 10 vessels
    for i in range(1, 11):
        VESSELS.append(Vessel(id=f"v{i:03}", name=f"Demo Vessel {i}"))
    
    # Create 20 activities distributed across all vessels
    for _ in range(20):
        vessel = random.choice(VESSELS)
        activity_type = random.choice(list(ActivityType))
        start, end = _random_activity_period()
        
        ACTIVITIES.append(
            Activity(
                id=str(uuid.uuid4()),
                vessel_id=vessel.id,
                type=activity_type,
                start=start,
                end=end
            )
        )


# Vessel operations
def get_vessel(vessel_id: str) -> Optional[Vessel]:
    """Get a vessel by ID."""
    for vessel in VESSELS:
        if vessel.id == vessel_id:
            return vessel
    return None


def get_vessels(name: Optional[str] = None, ids: Optional[List[str]] = None, year_of_build: Optional[int] = None) -> List[Vessel]:
    """Get vessels with optional filtering by name or IDs."""
    result = VESSELS
    
    if name:
        result = [v for v in result if name.lower() in v.name.lower()]
    
    if ids:
        result = [v for v in result if v.id in ids]

    if year_of_build is not None:
        result = [v for v in result if v.year_of_build == year_of_build]
    
    return result


def create_vessel(name: str, year_of_build: Optional[int] = None) -> Vessel:
    """Create a new vessel with a generated ID."""
    # Generate a new ID (v + 3-digit number)
    max_id = 0
    for vessel in VESSELS:
        if vessel.id.startswith('v'):
            try:
                num = int(vessel.id[1:])
                max_id = max(max_id, num)
            except ValueError:
                pass
    new_id = f"v{max_id + 1:03}"
    new_vessel = Vessel(id=new_id, name=name, year_of_build=year_of_build)
    VESSELS.append(new_vessel)
    return new_vessel



#name was tstr and not optional


def update_vessel(vessel_id: str, name: Optional[str] = None,  year_of_build: Optional[int] = None) -> Optional[Vessel]:
    """Update a vessel's name."""
    vessel = get_vessel(vessel_id)
    if vessel:
        # vessel.name = name
        if name is not None:
            vessel.name = name
        if year_of_build is not None:
            vessel.year_of_build = year_of_build
        return vessel
    return None


def delete_vessel(vessel_id: str) -> bool:
    """Delete a vessel and its activities."""
    vessel = get_vessel(vessel_id)
    if not vessel:
        return False
    
    # Remove the vessel
    VESSELS[:] = [v for v in VESSELS if v.id != vessel_id]
    
    # Remove associated activities
    ACTIVITIES[:] = [a for a in ACTIVITIES if a.vessel_id != vessel_id]
    
    return True


# Activity operations
def get_activity(activity_id: str) -> Optional[Activity]:
    """Get an activity by ID."""
    for activity in ACTIVITIES:
        if activity.id == activity_id:
            return activity
    return None


def create_activity(vessel_id: str, type_: ActivityType, start: datetime, end: datetime) -> Activity:
    """Create a new activity."""
    new_activity = Activity(
        id=str(uuid.uuid4()),
        vessel_id=vessel_id,
        type=type_,
        start=start,
        end=end
    )
    ACTIVITIES.append(new_activity)
    return new_activity


def delete_activity(activity_id: str) -> bool:
    """Delete an activity by ID."""
    activity = get_activity(activity_id)
    if not activity:
        return False
    
    ACTIVITIES[:] = [a for a in ACTIVITIES if a.id != activity_id]
    return True


def query_activities(
    rule: Callable[[Activity, Optional[datetime], Optional[datetime]], bool],
    *,
    vessel_ids: Optional[List[str]] = None,
    types: Optional[List[ActivityType]] = None,
    start: Optional[datetime] = None,
    end: Optional[datetime] = None
) -> List[Activity]:
    """
    Query activities using a rule function and optional filters.
    
    Args:
        rule: A function that takes an activity and optional start/end times and returns True if the activity matches
        vessel_ids: Optional list of vessel IDs to filter by
        types: Optional list of activity types to filter by
        start: Optional start datetime for the rule
        end: Optional end datetime for the rule
    
    Returns:
        List of matching activities
    """
    result = ACTIVITIES
    
    # Apply vessel filter if provided
    if vessel_ids:
        result = [a for a in result if a.vessel_id in vessel_ids]
    
    # Apply type filter if provided
    if types:
        result = [a for a in result if a.type in types]
    
    # Apply the time range rule
    result = [a for a in result if rule(a, start, end)]
    
    return result


# Initialize data on module import
seed_data()
