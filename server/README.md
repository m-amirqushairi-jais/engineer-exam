
# Server Engineer Examination: Docker and Azure Functions
> Created By Muhammad Amir Qushairi Jais

This examination is designed to evaluate your skills in containerization with Docker and the development of serverless functions using Azure Functions. You will complete two core tasks, focused on demonstrating your practical abilities.

**Prerequisites**

-   **Development Environment:** A suitable development environment with:
    
    -   Docker installed and configured
    -   Node.js **or** C# development tools (IDE, SDKs) – please specify your preference in advance.
    -   Azure Functions Core Tools (for local Function development)
    
-   **Azure Account (Optional):** If you wish to integrate Azure Blob Storage as part of the exam (Task 2 Extension), you can either:
    
    -   Use your personal Azure subscription.
    -   Request temporary access credentials from the examiner.
    

**Time Allocation:**

You will have approximately [Insert Time Limit] to complete the following tasks. Prioritize core functionality, but strive to demonstrate your broader understanding of cloud concepts.

## Task 1: Versioning and Configuration with Docker

Create a Docker container using your preferred language (Node.js or C#) for the Azure Function task. The container will perform version and configuration management.

1.  **Project Setup:**
    
    -   Create a new project directory.
    -   Include either a `package.json` (Node.js) or an appropriate C# project structure.
    -   Add a `config.json` file with the initial content:
        
        JSON
        
        ```
        {
           "buildnumber": "1.0.0"
        }
        
        ```
        
    
2.  **Script Functionality:**
    
    -   Write a script (`index.js` for Node.js or equivalent for C#) to:
        
        -   Read the `buildnumber` from `config.json`.
        -   Accept the following command-line arguments:
            
            -   `--version` or `-v`: Print the current version
            -   `--bump` or `-b`: Increment the minor version (e.g., 1.2.0 -> 1.3.0), updating `config.json`.
            -   `--output <filename>` or `-o <filename>`: Write the current version to the specified file.
            
        
    
3.  **Dockerfile:**
    
    -   Create a `Dockerfile` using the appropriate base image. Include instructions to copy project files, install dependencies, and define the default command that runs your script.
    
4.  **Build and Test**
    
    -   Build the image with a tag like `server-exam-tools`.
    -   Test the image with various command-line arguments to ensure all functionality works.
    

## Task 2: Azure Function Development

Develop an Azure Function using HTTP triggers in your chosen language (Node.js or C#).

**Option 1: Calculator Service**

-   **Core Functionality:**
    
    -   `GET /calculate?operation=<op>&num1=<value>&num2=<value>`
        
        -   Supported operations:  `add`,  `subtract`,  `multiply`,  `divide`
        
    -   Return the appropriate calculation result.
    
-   **Error Handling:**
    
    -   Return appropriate status codes and error messages for invalid operations, missing parameters, or division by zero.
    
-   **Testing (Description):**
    
    -   Outline how you would write unit tests for the Function. Provide a high-level test plan or use pseudocode.
    
-   **Deployment Considerations (Description):**
    
    -   Briefly discuss how you would consider scalability, monitoring, logging, and CI/CD for a production deployment.
    

**Option 2: ToDo CRUD + Blob Storage Extension**

-   **Core Functionality:**
    
    -   Implement the basic ToDo CRUD operations from the provided instructions (POST, GET, PUT, DELETE). Use in-memory storage initially.
    
-   **Extension - Blob Storage:**
    
    -   Integrate with Azure Blob Storage (Azurite for local or a provided Azure account).
    -   Serialize ToDo items (JSON) and store them in a Blob container for every creation, update, and deletion operation.
    

**Evaluation Criteria**

-   **Functionality:** Tasks are completed as per requirements.
-   **Code Quality:** Code is well-structured, readable, and includes meaningful comments.
-   **Azure Understanding:** Demonstrates knowledge of Azure Functions concepts.
-   **Problem-Solving:** Exhibits a logical approach to the tasks.
-   **Testing and Deployment Awareness:** Articulates sound strategies in written descriptions.

**Good Luck!**
