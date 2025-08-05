# import uplink
# from uplink import get, post, put, delete, Path, Query, Body
# from datetime import datetime
# from enum import Enum
# from typing import List, Optional
#
#
# # @uplink.json
# class ActivityType(str, Enum):
#     """Types of activities a vessel can perform."""
#     PORT_CALL = "port call"
#     BUNKERING = "bunkering"
#     ANCHORAGE = "anchorage"
#     TRANSIT = "transit"
#
#
# class VesselServiceClient(uplink.Consumer):
#     """Client for interacting with the Vessel Service API."""
#
#     def __init__(self, base_url="http://localhost:8000"):
#         super().__init__(base_url=base_url)
#
#     # Vessel endpoints
#
#     @get("/vessels/")
#     def get_vessels(self, name=Query(Optional[str]),
#                     ids=Query(Optional[str])):
#         """
#         Get all vessels with optional filtering.
#
#         Args:
#             name: Filter vessels by name (case-insensitive substring)
#             ids: Comma-separated list of vessel IDs to filter by
#         """
#         pass
#
#     @post("/vessels/")
#     # @json
#     @uplink.json
#     # def create_vessel(self, name: Body(str)):
#     def create_vessel(self, name=Body):
#         """
#         Create a new vessel.
#
#         Args:
#             name: Name of the vessel
#         """
#         pass
#
#     @get("/vessels/{vessel_id}")
#     def get_vessel(self, vessel_id=Path):
#         """
#         Get a specific vessel by ID.
#
#         Args:
#             vessel_id: ID of the vessel to get
#         """
#         pass
#
#     @put("/vessels/{vessel_id}")
#     # @json
#     @uplink.json
#     def update_vessel(self, vessel_id=Path, name=Body):
#         """
#         Update a vessel's name.
#
#         Args:
#             vessel_id: ID of the vessel to update
#             name: New name for the vessel
#         """
#         pass
#
#     @delete("/vessels/{vessel_id}")
#     def delete_vessel(self, vessel_id=Path):
#         """
#         Delete a vessel and all its activities.
#
#         Args:
#             vessel_id: ID of the vessel to delete
#         """
#         pass
#
#     @get("/vessels/{vessel_id}/activities")
#     def get_vessel_activities(self, vessel_id=Path):
#         """
#         Get all activities for a specific vessel.
#
#         Args:
#             vessel_id: ID of the vessel to get activities for
#         """
#         pass
#
#     # Activity endpoints
#
#     @get("/activities/")
#     def get_activities(self):
#         """Get all activities in the system."""
#         pass
#
#     @post("/activities/")
#     # @json
#     @uplink.json
#     def create_activity(self, vessel_id=Body,
#                         type=Body,
#                         start=Body,
#                         end=Body):
#         """
#         Create a new activity.
#
#         Args:
#             vessel_id: ID of the vessel performing the activity
#             type: Type of activity
#             start: Start time of the activity
#             end: End time of the activity
#         """
#         pass
#
#     @delete("/activities/{activity_id}")
#     def delete_activity(self, activity_id=Path):
#         """
#         Delete an activity.
#
#         Args:
#             activity_id: ID of the activity to delete
#         """
#         pass
#
#     # Time-based filtering endpoints
#
#     @post("/activities/overlapping")
#     # @json
#     @uplink.json
#     def get_overlapping_activities(self,
#                                    vessel_ids=Body,
#                                    types=Body,
#                                    start=Body,
#                                    end=Body):
#         """
#         Get activities that overlap with the given time range.
#
#         Args:
#             vessel_ids: Optional list of vessel IDs to filter by
#             types: Optional list of activity types to filter by
#             start: Optional start time boundary
#             end: Optional end time boundary
#         """
#         pass
#
#     @post("/activities/within")
#     # @json
#     @uplink.json
#     def get_activities_within_range(self,
#                                     vessel_ids=Body,
#                                     types=Body,
#                                     start=Body,
#                                     end=Body):
#         # vessel_ids: Body(Optional[List[str]]) = None,
#         # types: Body(Optional[List[ActivityType]]) = None,
#         # start: Body(Optional[datetime]) = None,
#         # end: Body(Optional[datetime]) = None):
#         """
#         Get activities that are completely within the given time range.
#
#         Args:
#             vessel_ids: Optional list of vessel IDs to filter by
#             types: Optional list of activity types to filter by
#             start: Optional start time boundary
#             end: Optional end time boundary
#         """
#         pass
#
#     @post("/activities/after")
#     # @json
#     @uplink.json
#     def get_activities_after(self,
#                              vessel_ids=Body,
#                              types=Body,
#                              start=Body):
#         # vessel_ids: Body(Optional[List[str]]) = None,
#         # types: Body(Optional[List[ActivityType]]) = None,
#         # start: Body(Optional[datetime]) = None):
#         """
#         Get activities that start after the given start time.
#
#         Args:
#             vessel_ids: Optional list of vessel IDs to filter by
#             types: Optional list of activity types to filter by
#             start: Optional start time boundary
#         """
#         pass
#
#     @post("/activities/before")
#     # @json
#     @uplink.json
#     def get_activities_before(self,
#                               vessel_ids=Body,
#                               types=Body,
#                               end=Body):
#         # vessel_ids: Body(Optional[List[str]]) = None,
#         # types: Body(Optional[List[ActivityType]]) = None,
#         # end: Body(Optional[datetime]) = None):
#         """
#         Get activities that end before the given end time.
#
#         Args:
#             vessel_ids: Optional list of vessel IDs to filter by
#             types: Optional list of activity types to filter by
#             end: Optional end time boundary
#         """
#         pass
#
import uplink
from uplink import get, post, put, delete, Path, Query, Body
from datetime import datetime
from enum import Enum
from typing import List, Optional

from vessel_service.models import ActivityCreate, Activity, VesselCreate, VesselUpdate


class ActivityType(str, Enum):
    """Types of activities a vessel can perform."""
    PORT_CALL = "port call"
    BUNKERING = "bunkering"
    ANCHORAGE = "anchorage"
    TRANSIT = "transit"


class VesselServiceClient(uplink.Consumer):
    """Client for interacting with the Vessel Service API."""

    def __init__(self, base_url="http://localhost:8000"):
        super().__init__(base_url=base_url)

    # Vessel endpoints

    @get("/vessels/")
    def get_vessels(self, name: Query = None, ids: Query = None, year_of_build: Query = None):
        """
        Get all vessels with optional filtering.

        Args:
            name: Filter vessels by name (case-insensitive substring)
            ids: Comma-separated list of vessel IDs to filter by
            year_of_build: Filter vessels by year of build
        """
        pass

    @uplink.json
    @post("/vessels/")
    def create_vessel(self, vessel: Body(type=VesselCreate)):
        """
        Create a new vessel.

        Args:
            vessel: VesselCreate object containing the name and year of build
        """
        pass

    @get("/vessels/{vessel_id}")
    def get_vessel(self, vessel_id: Path):
        """
        Get a specific vessel by ID.

        Args:
            vessel_id: ID of the vessel to get
        """
        pass

    @uplink.json
    @put("/vessels/{vessel_id}")
    def update_vessel(self, vessel_id: Path, vessel: Body(type=VesselUpdate)):
        """
        Update a vessel's name.

        Args:
            vessel_id: ID of the vessel to update
            vessel: VesselUpdate object containing the new name and year of build
        """
        pass

    @delete("/vessels/{vessel_id}")
    def delete_vessel(self, vessel_id: Path):
        """
        Delete a vessel and all its activities.

        Args:
            vessel_id: ID of the vessel to delete
        """
        pass

    @get("/vessels/{vessel_id}/activities")
    def get_vessel_activities(self, vessel_id: Path):
        """
        Get all activities for a specific vessel.

        Args:
            vessel_id: ID of the vessel to get activities for
        """
        pass

    # Activity endpoints

    @get("/activities/")
    def get_activities(self):
        """Get all activities in the system."""
        pass

    # @uplink.json
    # @post("/activities/")
    # def create_activity2(self, request: ActivityCreate):
    #     # body: Body):
    #     # vessel_id: Body,
    #     # type: Body,
    #     # start: Body,
    #     # end: Body):
    #     """
    #     Create a new activity.
    #
    #     Args:
    #         vessel_id: ID of the vessel performing the activity
    #         type: Type of activity
    #         start: Start time of the activity
    #         end: End time of the activity
    #     """
    #     pass

    @uplink.json
    @post("/activities/")
    def create_activity(self, request: Body):
        """
        Sends a request to create a new activity.

        Args:
            request (ActivityCreate): Activity data to be created.

        Returns:
            Activity: The created activity returned from the API.
        """
        pass

    @delete("/activities/{activity_id}")
    def delete_activity(self, activity_id: Path):
        """
        Delete an activity.

        Args:
            activity_id: ID of the activity to delete
        """
        pass

    # Time-based filtering endpoints

    @uplink.json
    @post("/activities/overlapping")
    def get_overlapping_activities(self,
                                   vessel_ids: Body = None,
                                   types: Body = None,
                                   start: Body = None,
                                   end: Body = None):
        """
        Get activities that overlap with the given time range.

        Args:
            vessel_ids: Optional list of vessel IDs to filter by
            types: Optional list of activity types to filter by
            start: Optional start time boundary
            end: Optional end time boundary
        """
        pass

    @uplink.json
    @post("/activities/within")
    def get_activities_within_range(self,
                                    vessel_ids: Body = None,
                                    types: Body = None,
                                    start: Body = None,
                                    end: Body = None):
        """
        Get activities that are completely within the given time range.

        Args:
            vessel_ids: Optional list of vessel IDs to filter by
            types: Optional list of activity types to filter by
            start: Optional start time boundary
            end: Optional end time boundary
        """
        pass

    @uplink.json
    @post("/activities/after")
    def get_activities_after(self,
                             vessel_ids: Body = None,
                             types: Body = None,
                             start: Body = None):
        """
        Get activities that start after the given start time.

        Args:
            vessel_ids: Optional list of vessel IDs to filter by
            types: Optional list of activity types to filter by
            start: Optional start time boundary
        """
        pass

    @uplink.json
    @post("/activities/before")
    def get_activities_before(self,
                              vessel_ids: Body = None,
                              types: Body = None,
                              end: Body = None):
        """
        Get activities that end before the given end time.

        Args:
            vessel_ids: Optional list of vessel IDs to filter by
            types: Optional list of activity types to filter by
            end: Optional end time boundary
        """
        pass

    @uplink.json
    @post("/activities/covering")
    def get_activities_covering(self,
                                vessel_ids: Body = None,
                                types: Body = None,
                                start: Body = None,
                                end: Body = None):
        """
        Get activities that fully cover the given time range.

        Args:
            vessel_ids: Optional list of vessel IDs to filter by
            types: Optional list of activity types to filter by
            start: Optional start time boundary
            end: Optional end time boundary
        """
        pass
