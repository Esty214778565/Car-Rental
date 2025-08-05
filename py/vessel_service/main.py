from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from vessel_service.routers import vessels, activities
import logging
logger = logging.getLogger(__name__)
app = FastAPI(
    title="Vessel Activity Service",
    description="A service for tracking vessel activities with sophisticated time-based filtering",
    version="1.0.0",
)

# Add CORS middleware to allow cross-origin requests
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],  # In production, replace with specific origins
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Include routers
app.include_router(vessels.router)
app.include_router(activities.router)


@app.get("/", tags=["health"])
async def root():
    """
    Root endpoint for health checks.
    """
    return {
        "status": "healthy",
        "service": "vessel-activity-service",
        "version": "1.0.0"
    }


# If this script is run directly, start the server
if __name__ == "__main__":
        logging.basicConfig(

             filename='try.txt',

             level=logging.INFO,

             format='%(asctime)s - %(levelname)s - %(message)s')

        logger.info("Starting Vessel Activity Service...")




        import uvicorn
        uvicorn.run("vessel_service.main:app", host="0.0.0.0", port=8000, reload=True)
