from typing import List, Optional
from fastapi import APIRouter, HTTPException, Query, Path, Body
from vessel_service import storage
from vessel_service.models import Vessel, VesselCreate, VesselUpdate, Activity
import logging
logger = logging.getLogger(__name__)
router = APIRouter(
    prefix="/vessels",
    tags=["vessels"],
    responses={404: {"description": "Vessel not found"}},
)


@router.get("/", response_model=List[Vessel])
async def list_vessels(
        name: Optional[str] = Query(None, description="Filter vessels by name (case-insensitive substring)"),
        ids: Optional[str] = Query(None, description="Comma-separated list of vessel IDs to filter by"),
        year_of_build: Optional[int] = Query(None, description="Filter vessels by year of build")
):
    """
    List all vessels with optional filtering by name or IDs.
    """
    id_list = ids.split(",") if ids else None
    return storage.get_vessels(name=name, ids=id_list, year_of_build=year_of_build)


@router.post("/", response_model=Vessel, status_code=201)
async def create_vessel(vessel: VesselCreate = Body(...)):
    """
    Create a new vessel.
    """

    logger.info(f"Creating vessel: {vessel.name}, Year of Build: {vessel.year_of_build}")
    return storage.create_vessel(name=vessel.name, year_of_build=vessel.year_of_build)


@router.get("/{vessel_id}", response_model=Vessel)
async def get_vessel(vessel_id: str = Path(..., description="ID of the vessel to get")):
    """
    Get a specific vessel by ID.
    """
    vessel = storage.get_vessel(vessel_id)
    if not vessel:
        raise HTTPException(status_code=404, detail=f"Vessel {vessel_id} not found")
    return vessel


@router.put("/{vessel_id}", response_model=Vessel)
async def update_vessel(
        vessel_id: str = Path(..., description="ID of the vessel to update"),
        vessel_update: VesselUpdate = Body(...)
):
    """
    Update a vessel's details.
    """
    updated_vessel = storage.update_vessel(vessel_id,
                                           name=vessel_update.name,
                                           year_of_build=vessel_update.year_of_build
                                           )
    if not updated_vessel:
        raise HTTPException(status_code=404, detail=f"Vessel {vessel_id} not found")
    return updated_vessel


@router.delete("/{vessel_id}", status_code=204)
async def delete_vessel(vessel_id: str = Path(..., description="ID of the vessel to delete")):
    """
    Delete a vessel and all its activities.
    """
    success = storage.delete_vessel(vessel_id)
    if not success:
        raise HTTPException(status_code=404, detail=f"Vessel {vessel_id} not found")
    return None


@router.get("/{vessel_id}/activities", response_model=List[Activity])
async def get_vessel_activities(
        vessel_id: str = Path(..., description="ID of the vessel to get activities for")
):
    """
    Get all activities for a specific vessel.
    """
    # First check if vessel exists
    vessel = storage.get_vessel(vessel_id)
    if not vessel:
        raise HTTPException(status_code=404, detail=f"Vessel {vessel_id} not found")

    # Use the query function with a simple rule that always returns True
    # but filter by the vessel_id
    return storage.query_activities(
        rule=lambda a, s, e: True,
        vessel_ids=[vessel_id]
    )
