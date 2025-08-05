FROM python:3.11-slim

ENV PYTHONDONTWRITEBYTECODE=1 \
    PYTHONUNBUFFERED=1

WORKDIR /app

# Copy poetry configuration files
COPY pyproject.toml poetry.lock* /app/

# Install poetry and dependencies
RUN pip install --no-cache-dir poetry && \
    poetry config virtualenvs.create false && \
    poetry install --without dev --no-interaction --no-root

# Copy application code
COPY vessel_service /app/vessel_service
COPY vessel_streamlit_app /app/vessel_streamlit_app
COPY vessel_api_client /app/vessel_api_client

# Expose the ports for both FastAPI and Streamlit
EXPOSE 8000 8501

# Create a script to run both services
RUN echo '#!/bin/bash\n\
uvicorn vessel_service.main:app --host 0.0.0.0 --port 8000 & \n\
streamlit run vessel_streamlit_app/app.py --server.port 8501 --server.address 0.0.0.0\n' > /app/start.sh && \
    chmod +x /app/start.sh

# Command to run both applications
CMD ["/app/start.sh"]
