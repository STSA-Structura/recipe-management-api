# recipe-management-api

A .NET 8 Web API for managing recipes, ingredients, and related user functionalities.

## Purpose

The **Recipe Management API** is designed to support CRUD operations for recipes and ingredients, enable secure user authentication, and facilitate advanced search and filtering.

## Folder Structure

```text
recipe-management-api/
 ├── src/                          # Main source code for the API
 ├── tests/                        # Test suite for validating API functionalities
 ├── docs/                         # Documentation resources
 │   ├── README.md                 # Overview of the API, purpose, and usage guidelines
 │   ├── API_Specifications/
 │   │   └── OpenAPI.yaml          # API specification (Swagger/OpenAPI)
 │   ├── Authentication_Guide.md   # Documentation on authentication requirements and flows
 │   ├── Deployment_Guide.md       # Instructions for deploying the API across environments
 │   ├── Models/
 │   │   ├── Recipe.md             # Documentation for the Recipe model
 │   │   └── Ingredient.md         # Documentation for the Ingredient model
 │   └── CI_CD_Pipeline.md         # Details on CI/CD setup and processes
 ├── Dockerfile                    # Docker configuration for containerization
 ├── README.md                     # Main repository README, links to documentation in `docs/`
 └── .gitignore                    # Ignore file to specify files and directories to ignore in version control
```

### Steps to Populate the `docs/` Folder

> 1. `README.md`: Provide an overview of the API, usage instructions, and links to other documentation files.
> 1. `API_Specifications`: Store OpenAPI or Swagger files, updated regularly as you add new endpoints or functionality.
> 1. `Models`: Create a .md file for each core model (e.g., Recipe.md, Ingredient.md), detailing fields, relationships, and validation rules.
> 1. `Authentication_Guide.md`: Document authentication flows, such as OAuth or token-based access.
> 1. `Deployment_Guide.md`: Provide environment-specific deployment configurations (e.g., Dev, Staging, Prod).
> 1. `CI_CD_Pipeline.md`: Describe the CI/CD process, including tools (e.g., GitHub Actions, Azure Pipelines) and pipeline stages.

This structure is flexible and can expand over time, especially as you add more features or documentation needs.

## Quick Start

```powershell
# Clone the repository
git clone <repository-url>
cd recipe-management-api

# Install dependencies
dotnet restore

# Run the API
dotnet run --project src/recipe-management-api
```

## API Documentation

View the API specifications by navigating to /swagger after the API is running.
Full documentation can be found in the API Specifications file.

## Contributing

If you'd like to contribute, please read through our [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines on submitting pull requests, documentation updates, or reporting issues.
