# Instructions

Welcome to the test! 🎉

In this exercise, you'll be working with a Vessel Service API to replace direct API calls with an API client. You'll refactor the existing code to interact with the API more efficiently, implement missing functionality in the client, and write tests to ensure everything works as expected.

## Setup Instructions

### Step 1: Install Project Dependencies

1. Clone the repository.
2. Install Poetry by following the instructions at [Poetry Install Guide](https://python-poetry.org/docs/#installation).
3. Once Poetry is installed, navigate to the project directory and install the dependencies using:

   ```bash
   poetry install
   ```

   This will install all necessary dependencies, including Streamlit, pytest, uplink, requests, and others.

### Step 2: Run the Application

1. After installing the dependencies, run the Streamlit app:

   ```bash
   .venv/bin/streamlit run vessel_streamlit_app/app.py
   ```

2. The app should open in your browser (http://localhost:8501/).

---

## Your task

1. Currently, the Streamlit app makes direct HTTP requests to fetch vessel and activity data from the Vessel Service API. Your task is to replace these direct API calls with the provided `VesselServiceClient` client.

2. Add support in the client for an existing endpoint that is not yet implemented in the client. Specifically, implement the `/activities/covering` endpoint and use it in the Streamlit app.

3. Enhance the vessel entity by adding a `year_of_build` field and implement search functionality for this field in the service, as well as in the client and the Streamlit app.

4. Expand the test suite to include meaningful tests for the `VesselServiceClient`. Use pytest fixtures for working with the client, and add a coverage tool for tracking the code coverage.

### 📌 Please Note

1. You don't need to test the Streamlit app - focus on testing the API service and client.
2. You can modify existing files and add new code as needed.
3. Make sure the Streamlit app works correctly with your updated client.
4. Write meaningful unit tests with coverage for the client.
5. Ensure your code is clean, well-structured, and free of unused code.

---

## Submission

Push your changes to the repository and let us know when you are ready for review.
Ensure that your commit history shows incremental changes. Please add a `README.md` that explains:
   - How to run the app and tests  
   - How to check test coverage
   - What you learned from this exercise and what helped you succeed
   - Any notes or external resources you used (encouraged!)


### Good luck!
