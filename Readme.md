# API Documentation

## Introduction

This application exposes API to create a program using a simple form, update the program after creating, and applying to the program using a simple form. This application is built using .NET Core 8 WEB API and cosmos db as database.

## Running the Application

- Ensure you have Azure Cosmos Db Emulator running. If you want to use Cosmos Db provisioned on Azure Portal, update the primary key in configuration.
- You are set to run the application
- Sample payload [here](./samplepayload.json)

## Endpoints

### Candidate

#### Submit Application [/apply]

- **Method**: `POST`
- **Summary**: Submit application for a program/job offering
- **Request Body**:
  
  - **Description**: The response to the program questions
  
  - **Content**:
    - `application/json`
    - `text/json`
    - `application/*+json`

- **Responses**:
  - `201` Created
  - `500` Server Error

### Employer

#### Create Program Offering [/program]

- **Method**: `POST`
- **Summary**: Create a new program offering
- **Request Body**:

  - **Content**:
    - `application/json`

- **Responses**:
  - `201` Created
    - **Content**:
      - `text/plain`
      - `application/json`
      - `text/json`
  - `500` Server Error

#### Update Program [/program]

- **Method**: `PUT`
- **Summary**: Update an existing program
- **Request Body**:

  - **Content**:
    - `application/json`

- **Responses**:
  - `200` Success
    - **Content**:
      - `text/plain`
      - `application/json`
      - `text/json`
  - `404` Not Found
    - **Content**:
      - `text/plain`
      - `application/json`
      - `text/json`
  - `500` Server Error

#### Get Program Offering [/program/{id}]

- **Method**: `GET`
- **Summary**: Get a specific program offering
- **Parameters**:
  - `id` (path, required) - ID of the program offering
- **Responses**:
  - `200` Success
    - **Content**:
      - `text/plain`
      - `application/json`
      - `text/json`
  - `404` Not Found
    - **Content**:
      - `text/plain`
      - `application/json`
      - `text/json`
  - `500` Server Error

## Data Models

### CreateApplicationRequest

- **programId** (string, optional)
- **personalInformation** (array of CandidateResponse, optional)
- **programResponses** (array of CandidateResponse, optional)

### CreateOfferingRequest

- **title** (string)
- **description** (string)
- **requestPhone** (boolean)
- **requestNationality** (boolean)
- **requestCurrentResidence** (boolean)
- **requestIDNumber** (boolean)
- **requestGender** (boolean)
- **additionalPersonalInformation** (array of ProgramQuestion)
- **programQuestions** (array of ProgramQuestion)

### CreateOfferingResponse

- **id** (string)
- **title** (string)
- **description** (string)
- **personalInformation** (array of ProgramQuestion)
- **programQuestions** (array of ProgramQuestion)

### ProgramQuestion

- **type** (QuestionType)
- **question** (string)
- **choice** (array of string, optional)
- **maxChoice** (integer, optional)

### CandidateResponse

- **type** (QuestionType)
- **question** (string)
- **response** (any)

### UpdateOfferingRequest

- **id** (string)
- **title** (string)
- **description** (string)
- **personalInformation** (array of ProgramQuestion)
- **programQuestions** (array of ProgramQuestion)

### QuestionType

- Enum: [Paragraph = 0,
        YesNo = 1,
        Dropdown = 2,
        MultiChoice = 3,
        Date = 4,
        Number = 5]

## Version

- **Title**: API
- **Version**: 1.0
