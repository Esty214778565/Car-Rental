# Windward Python Test - Vessel Activity Tracker

A FastAPI-based microservice for tracking vessels and their activities with sophisticated time-based filtering capabilities.


## Features

- In-memory storage of vessels and activities
- CRUD operations for vessels
- Time-based filtering for activities:
  - Activities overlapping with a time range
  - Activities completely within a time range
  - Activities after a specific time
  - Activities before a specific time
  - Activities covering a time range
- Dockerized for easy deployment

## Prerequisites

- Python 3.8+
- Poetry for dependency management
- Docker (optional, for containerized deployment)

## Installation

### Using Poetry (Recommended)

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd python-streamlit-test-no-auth-fixed
   ```

2. Install dependencies using Poetry:
   ```bash
   poetry install
   ```

3. Run the service:
   ```bash
   poetry run python -m uvicorn vessel_service.main:app --reload
   ```

The service will be available at http://localhost:8000.

### Using Docker

1. Build the Docker image:
   ```bash
   docker build -t vessel-service .
   ```

2. Run the container:
   ```bash
   docker run -p 8000:8000 vessel-service
   ```

The service will be available at http://localhost:8000.

## API Documentation

Once the service is running, you can access the interactive API documentation:

- Swagger UI: http://localhost:8000/docs
- ReDoc: http://localhost:8000/redoc

## API Endpoints

### Vessels

- `GET /vessels/` - List all vessels (optional query params: `name`, `ids`)
- `POST /vessels/` - Create a new vessel
- `GET /vessels/{id}` - Get a specific vessel
- `PUT /vessels/{id}` - Update a vessel
- `DELETE /vessels/{id}` - Delete a vessel and its activities
- `GET /vessels/{id}/activities` - Get all activities for a vessel

### Activities

- `GET /activities/` - List all activities
- `POST /activities/` - Create a new activity
- `DELETE /activities/{id}` - Delete an activity

### Time-based Activity Filtering

All these endpoints accept a JSON body with the following optional fields:
```json
{
  "vessel_ids": ["v001", "v002"],
  "types": ["port call", "bunkering"],
  "start": "2025-07-01T00:00:00Z",
  "end": "2025-07-31T23:59:59Z"
}
```

- `POST /activities/overlapping` - Activities that overlap with the given time range
- `POST /activities/within` - Activities completely within the given time range
- `POST /activities/after` - Activities starting after the given start time
- `POST /activities/before` - Activities ending before the given end time
- `POST /activities/covering` - Activities that completely cover the given time range

## Example Usage

### List all vessels
```bash
curl -X GET http://localhost:8000/vessels/
```

### Get activities overlapping with July 10-20, 2025
```bash
curl -X POST http://localhost:8000/activities/overlapping \
  -H "Content-Type: application/json" \
  -d '{"start": "2025-07-10T00:00:00", "end": "2025-07-20T00:00:00"}'
```

### Get port call activities for specific vessels
```bash
curl -X POST http://localhost:8000/activities/within \
  -H "Content-Type: application/json" \
  -d '{"vessel_ids": ["v001", "v002"], "types": ["port call"], "start": "2025-07-01T00:00:00", "end": "2025-07-31T00:00:00"}'
```

## Testing

Run the test suite:
```bash
poetry run pytest vessel_service/tests/
```
