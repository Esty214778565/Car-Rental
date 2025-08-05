import sys
import os
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))
import vessel_service.models as models
import requests
import streamlit as st
import pandas as pd
from datetime import datetime, timedelta
from vessel_api_client.vessel_api_client.client import VesselServiceClient
from vessel_service.models import ActivityType

# API Configuration
BASE_URL = "http://localhost:8000"
client = VesselServiceClient(base_url=BASE_URL)

# Activity types
ACTIVITY_TYPES = ["port call", "bunkering", "anchorage", "transit"]


def format_datetime(dt):
    """Format datetime for display"""
    if isinstance(dt, str):
        try:
            dt = datetime.fromisoformat(dt.replace('Z', '+00:00'))
        except ValueError:
            return dt
    return dt.strftime("%Y-%m-%d %H:%M")


#treat yo_build
# Vessel API Functions


def get_vessels(name=None, ids=None, year_of_build=None):
    """Get all vessels with optional filtering"""
    params = {}
    if name:
        params['name'] = name
    if ids:
        params['ids'] = ','.join(ids)
    response = requests.get(f"{BASE_URL}/vessels/", params=params)

    # if isinstance(ids, list):
    #     ids = ",".join(map(str, ids))
    # response = client.get_vessels(name=name, ids=ids, year_of_build=year_of_build)
    if response.status_code == 200:
        return response.json()
    else:
        st.error(f"Error fetching vessels: {response.status_code}")
        return []


def create_vessel(name):
    """Create a new vessel"""
    response = client.create_vessel({"name": name})
    if response.status_code == 201:
        return response.json()
    else:
        st.error(f"Error creating vessel: {response.status_code}")
        return None


def delete_vessel(vessel_id):
    """Delete a vessel"""
    response = client.delete_vessel(vessel_id)
    return response.status_code == 204


# Activity API Functions
def get_activities():
    """Get all activities"""
    response = client.get_activities()
    if response.status_code == 200:
        return response.json()
    else:
        st.error(f"Error fetching activities: {response.status_code}")
        return []


def create_activity(vessel_id: str, activity_type: str, start: datetime, end: datetime):
    try:
        activity_data = models.ActivityCreate(
            vessel_id=vessel_id,
            type=ActivityType(activity_type),
            start=start,
            end=end
        )
        response = client.create_activity(activity_data.model_dump())
        st.success(f"Activity created successfully! ID: {response.id}")
    except Exception as e:
        st.error(f"Failed to create activity: {e}")


def create_activity2(vessel_id, activity_type, start, end):
    """Create a new activity"""
    print("******************"+vessel_id, activity_type, start, end)
    payload = models.ActivityCreate(
        vessel_id=vessel_id,
        type=models.ActivityType(activity_type) if isinstance(activity_type, str) else activity_type,
        start=start,
        end=end
    )
    print("Payload type:", type(payload))
    print("Payload value:", payload)
    print("Payload base classes:", models.ActivityCreate.__bases__)
    print(payload.model_dump_json())
    response = client.create_activity(payload)

    # response = requests.post(f"{BASE_URL}/activities/", json=data)
    if response.status_code == 201:
        return response.json()
    else:
        st.error(f"Error creating activity: {response.status_code} - {response.text}")
        return None


def delete_activity(activity_id):
    """Delete an activity"""
    response = client.delete_activity(activity_id)
    #response = requests.delete(f"{BASE_URL}/activities/{activity_id}")
    return response.status_code == 204


# def filter_activities(filter_params):
#     """Filter activities based on parameters"""
#     # Remove None values
#     filter_params = {k: v for k, v in filter_params.items() if v is not None}
#
#     # Convert datetime objects to ISO format strings
#     if 'start' in filter_params and filter_params['start']:
#         filter_params['start'] = filter_params['start'].isoformat()
#     if 'end' in filter_params and filter_params['end']:
#         filter_params['end'] = filter_params['end'].isoformat()
#
#     # Choose the appropriate endpoint based on the filter type
#     filter_type = filter_params.pop('filter_type', 'overlapping')
#
#     response = requests.post(f"{BASE_URL}/activities/{filter_type}", json=filter_params)
#     if response.status_code == 200:
#         return response.json()
#     else:
#         st.error(f"Error filtering activities: {response.status_code}")
#         return []

# def filter_activities2(filter_params):
#     """Filter activities based on parameters using uplink client - cleaner version"""
#     try:
#         params = {k: v for k, v in filter_params.items() if v is not None}
#
#         for date_field in ['start', 'end']:
#             if date_field in params and params[date_field]:
#                 params[date_field] = params[date_field].isoformat()
#
#         filter_type = params.pop('filter_type', 'overlapping')
#
#         method_map = {
#             'overlapping': client.get_overlapping_activities,
#             'within': client.get_activities_within_range,
#             'after': client.get_activities_after,
#             'before': client.get_activities_before
#         }
#
#         method = method_map.get(filter_type)
#         if not method:
#             st.error(f"Unknown filter type: {filter_type}")
#             return []
#
#         if filter_type == 'after':
#             params.pop('end', None)
#         elif filter_type == 'before':
#             params.pop('start', None)
#
#         response = method(**params)
#         return response if response else []
#
#     except Exception as e:
#         st.error(f"Error filtering activities: {str(e)}")
#         return []

def filter_activities(filter_params):
    """Filter activities based on parameters using uplink client - cleaner version"""
    try:
        params = {k: v for k, v in filter_params.items() if v is not None}

        for date_field in ['start', 'end']:
            if date_field in params and params[date_field]:
                params[date_field] = params[date_field].isoformat()

        filter_type = params.pop('filter_type', 'overlapping')

        method_map = {
            'overlapping': client.get_overlapping_activities,
            'within': client.get_activities_within_range,
            'after': client.get_activities_after,
            'before': client.get_activities_before,
            'covering': client.get_activities_covering
        }

        method = method_map.get(filter_type)
        if not method:
            st.error(f"Unknown filter type: {filter_type}")
            return []

        if filter_type == 'after':
            params.pop('end', None)
        elif filter_type == 'before':
            params.pop('start', None)

        response = method(**params)
        return response if response else []

    except Exception as e:
        st.error(f"Error filtering activities: {str(e)}")
        return []


def vessels_tab():
    st.header("Vessels")

    st.subheader("Add New Vessel")
    with st.form("add_vessel_form"):
        vessel_name = st.text_input("Vessel Name", key="vessel_name")
        submit_button = st.form_submit_button("Add Vessel")

        if submit_button and vessel_name:
            new_vessel = create_vessel(vessel_name)
            if new_vessel:
                st.success(f"Vessel '{vessel_name}' created with ID: {new_vessel['id']}")

    st.subheader("Filter Vessels")
    name_filter = st.text_input("Filter by Name", key="name_filter")
    year_filter = st.number_input("Filter by Year of Build", min_value=1800, max_value=2100, step=1, format="%d", key="year_filter")
    if st.button("Apply Filter"):
        filtered_vessels = get_vessels(name=name_filter, year_of_build=year_filter if year_filter else None)
        st.session_state.vessels = filtered_vessels

    st.subheader("Vessels List")
    if st.button("Refresh Vessels"):
        st.session_state.vessels = get_vessels()

    # Display vessels in a table
    if 'vessels' not in st.session_state:
        st.session_state.vessels = get_vessels()

    if st.session_state.vessels:
        df = pd.DataFrame(st.session_state.vessels)
        st.dataframe(df)

        # Delete vessel functionality
        st.subheader("Delete Vessel")
        vessel_to_delete = st.selectbox(
            "Select Vessel to Delete",
            options=[v["id"] for v in st.session_state.vessels],
            format_func=lambda x: f"{x} - {next((v['name'] for v in st.session_state.vessels if v['id'] == x), '')}",
            key="vessel_to_delete"
        )

        if st.button("Delete Selected Vessel"):
            if delete_vessel(vessel_to_delete):
                st.success(f"Vessel {vessel_to_delete} deleted successfully")
                st.session_state.vessels = [v for v in st.session_state.vessels if v["id"] != vessel_to_delete]
            else:
                st.error("Failed to delete vessel")
    else:
        st.info("No vessels found")


def activities_tab():
    st.header("Activities")
    if 'activities' not in st.session_state:
        st.session_state.activities = []
    st.subheader("Add New Activity")

    # Get vessels for dropdown
    if 'vessels' not in st.session_state:
        st.session_state.vessels = get_vessels()

    with st.form("add_activity_form"):
        vessel_id = st.selectbox(
            "Vessel",
            options=[v["id"] for v in st.session_state.vessels],
            format_func=lambda x: f"{x} - {next((v['name'] for v in st.session_state.vessels if v['id'] == x), '')}",
            key="vessel_id"
        )

        activity_type = st.selectbox("Activity Type", options=ACTIVITY_TYPES, key="activity_type")

        # Date and time inputs without nested columns
        st.write("Start Date/Time:")
        start_date = st.date_input("Start Date", value=datetime.now(), key="start_date")
        start_time = st.time_input("Start Time", value=datetime.now().time(), key="start_time")

        st.write("End Date/Time:")
        end_date = st.date_input("End Date", value=datetime.now() + timedelta(hours=2), key="end_date")
        end_time = st.time_input("End Time", value=datetime.now().time(), key="end_time")

        start_datetime = datetime.combine(start_date, start_time)
        end_datetime = datetime.combine(end_date, end_time)

        submit_button = st.form_submit_button("Add Activity")

        if submit_button:
            print("Submit clicked")
            print("Start:", start_datetime)
            print("End:", end_datetime)
            print("Vessel ID:", vessel_id)
            print("Activity type:", activity_type)
            if start_datetime >= end_datetime:
                st.error("End time must be after start time")
            else:
                new_activity = create_activity(vessel_id, activity_type, start_datetime, end_datetime)
                if new_activity:
                    st.success(f"Activity created for vessel {vessel_id}")
                    if 'activities' in st.session_state:
                        st.session_state.activities.append(new_activity)

    st.subheader("Filter Activities")
    with st.form("filter_activities_form"):
        filter_type = st.selectbox(
            "Filter Type",
            options=["overlapping", "within", "after", "before", "covering"],
            format_func=lambda x: x.capitalize(),
            key="filter_type"
        )

        # Get vessels for multiselect
        vessel_ids = st.multiselect(
            "Vessels",
            options=[v["id"] for v in st.session_state.vessels],
            format_func=lambda x: f"{x} - {next((v['name'] for v in st.session_state.vessels if v['id'] == x), '')}",
            key="vessel_ids"
        )

        activity_types = st.multiselect("Activity Types", options=ACTIVITY_TYPES, key="activity_types")

        # Date and time inputs without nested columns
        st.write("From:")
        filter_start_date = st.date_input("From Date", value=datetime.now() - timedelta(days=7),
                                          key="filter_start_date")
        filter_start_time = st.time_input("From Time", value=datetime.min.time(), key="filter_start_time")

        st.write("To:")
        filter_end_date = st.date_input("To Date", value=datetime.now() + timedelta(days=7), key="filter_end_date")
        filter_end_time = st.time_input("To Time", value=datetime.max.time(), key="filter_end_time")

        filter_start = datetime.combine(filter_start_date, filter_start_time)
        filter_end = datetime.combine(filter_end_date, filter_end_time)

        filter_button = st.form_submit_button("Apply Filter")

        if filter_button:
            filter_params = {
                "filter_type": filter_type,
                "vessel_ids": vessel_ids if vessel_ids else None,
                "types": activity_types if activity_types else None,
                "start": filter_start,
                "end": filter_end
            }
            st.session_state.activities = filter_activities(filter_params)

    st.subheader("Activities List")
    if st.button("Show All Activities"):
        st.session_state.activities = get_activities()

    # Display activities in a table
    if 'activities' not in st.session_state:
        st.session_state.activities = get_activities()

    if st.session_state.activities:
        # Create a DataFrame and format the datetime columns
        activities_data = []
        for activity in st.session_state.activities:
            activities_data.append({
                "id": activity["id"],
                "vessel_id": activity["vessel_id"],
                "vessel_name": next((v['name'] for v in st.session_state.vessels if v['id'] == activity["vessel_id"]),
                                    "Unknown"),
                "type": activity["type"],
                "start": format_datetime(activity["start"]),
                "end": format_datetime(activity["end"])
            })

        df = pd.DataFrame(activities_data)
        st.dataframe(df)

        # Delete activity functionality
        st.subheader("Delete Activity")
        activity_to_delete = st.selectbox(
            "Select Activity to Delete",
            options=[a["id"] for a in st.session_state.activities],
            key="activity_to_delete"
        )

        if st.button("Delete Selected Activity"):
            if delete_activity(activity_to_delete):
                st.success(f"Activity {activity_to_delete} deleted successfully")
                st.session_state.activities = [a for a in st.session_state.activities if a["id"] != activity_to_delete]
            else:
                st.error("Failed to delete activity")
    else:
        st.info("No activities found")


def main():
    st.set_page_config(
        page_title="Windward Vessel Activity Tracker",
        page_icon="🚢",
        layout="wide"
    )

    st.title("🚢 Windward Vessel Activity Tracker")

    # Check if the API is available
    try:
        response = requests.get(f"{BASE_URL}/")
        if response.status_code != 200:
            st.error(f"API is not available. Please make sure the vessel service is running at {BASE_URL}")
            return
    except requests.exceptions.ConnectionError:
        st.error(f"Cannot connect to the API at {BASE_URL}. Please make sure the vessel service is running.")
        return

    # Create tabs
    vessels_tab_ui, activities_tab_ui = st.tabs(["Vessels", "Activities"])

    with vessels_tab_ui:
        vessels_tab()

    with activities_tab_ui:
        activities_tab()


if __name__ == "__main__":
    main()
