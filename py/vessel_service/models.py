from datetime import datetime
from enum import Enum
from typing import List, Optional
from pydantic import BaseModel, Field


class Vessel(BaseModel):
    """Vessel model representing a ship in the system."""
    id: str = Field(..., description="Unique vessel identifier")
    name: str = Field(..., description="Name of the vessel")
    year_of_build: Optional[int] = Field(None, description="Year the vessel was built")


class ActivityType(str, Enum):
    """Types of activities a vessel can perform."""
    PORT_CALL = "port call"
    BUNKERING = "bunkering"
    ANCHORAGE = "anchorage"
    TRANSIT = "transit"


class Activity(BaseModel):
    """Activity performed by a vessel with start and end times."""
    id: str = Field(..., description="Unique activity identifier")
    vessel_id: str = Field(..., description="ID of the vessel performing the activity")
    type: ActivityType = Field(..., description="Type of activity")
    start: datetime = Field(..., description="Start time of the activity")
    end: datetime = Field(..., description="End time of the activity")


class RangeFilter(BaseModel):
    """Common filter model for querying activities by time range and other criteria."""
    vessel_ids: Optional[List[str]] = Field(None, description="Optional list of vessel IDs to filter by")
    types: Optional[List[ActivityType]] = Field(None, description="Optional list of activity types to filter by")
    start: Optional[datetime] = Field(None, description="Optional start time boundary")
    end: Optional[datetime] = Field(None, description="Optional end time boundary")


class VesselCreate(BaseModel):
    """Model for creating a new vessel."""
    name: str = Field(..., description="Name of the vessel")
    year_of_build: Optional[int] = Field(None, description="Year the vessel was built")


class VesselUpdate(BaseModel):
    """Model for updating an existing vessel."""
    name: str = Field(..., description="Updated name of the vessel")
    year_of_build: Optional[int] = Field(None, description="Updated year the vessel was built")


class ActivityCreate(BaseModel):
    """Model for creating a new activity."""
    vessel_id: str = Field(..., description="ID of the vessel performing the activity")
    type: ActivityType = Field(..., description="Type of activity")
    start: datetime = Field(..., description="Start time of the activity")
    end: datetime = Field(..., description="End time of the activity")


class VesselFilter(BaseModel):
    """Model for filtering vessels based on various criteria."""
    name: Optional[str] = None
    ids: Optional[List[str]] = None
    year_of_build: Optional[int] = None
