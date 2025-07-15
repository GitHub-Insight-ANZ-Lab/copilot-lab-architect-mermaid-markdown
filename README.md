# GitHub Copilot Lab for Leads & Architects

A hands-on lab to introduce leads & architects to working with GitHub Copilot to understand code, generate documentation in Markdown format, generate diagrams using Mermaid and using Copilot for code reviews. You do not need to have any prior experience with Mermaid or Markdown to complete this lab! There is an ASP.NET Core 8 REST API included as the solution to document & understand.

**Proposed duration:** 60-120 minutes (excluding prerequisites setup).

## Prerequisites
To get started, please ensure you have these tools installed.

- [Visual Studio Code](https://code.visualstudio.com/)
- [GitHub Copilot](https://copilot.github.com/) installed and licensed
- [Markdown Preview Mermaid Support](https://marketplace.visualstudio.com/items?itemName=bierner.markdown-mermaid) extension for Visual Studio Code

The labs you can complete depend on your GitHub Copilot license type:

### Copilot Business:

- Explain this solution / codebase
- Ask for suggestions / improvements around insecure coding practices
- Document methods / classes
- Generate a README.md file that gives new developers guidance on how to get up and going with the solution
- Generate diagrams using mermaid
	- ERD
 	- Sequence Diagram
	- Azure Solution Architecture
	
### Copilot Enterprise:
- Query a repo
- PR descriptions
- PR Review with Copilot
- Building a knowledge base

## Lab Setup

Setting Up GitHub Copilot in Visual Studio Code. 

1. **Install Visual Studio Code:**
    - If you haven't already, download and install Visual Studio Code from [here](https://code.visualstudio.com/).

2. **Install GitHub Copilot:**
    - Open Visual Studio Code.
    - Go to the Extensions view by clicking on the Extensions icon in the Activity Bar on the side of the window or by pressing `Cmd+Shift+X`.
    - Search for "GitHub Copilot" and click the "Install" button.

3. **Sign In to GitHub Copilot:**
    - After installation, you will be prompted to sign in to GitHub Copilot.
    - Follow the on-screen instructions to authenticate with your GitHub account.

4. **Verify Installation:**
    - Open a new file in Visual Studio Code.
    - Start typing a comment or a piece of code, and you should see suggestions from GitHub Copilot.
    - If you see suggestions, GitHub Copilot is successfully installed and ready to use.
  
## Getting started

1. **Basic Usage:**

    - Create a new JavaScript file (`example.js`).
    - Start typing a function definition, e.g. `function add(a, b) {`.
    - Observe how GitHub Copilot suggests the implementation of the function.
    - Accept the suggestion by pressing `Tab`.
    
2. **Exploring Different Features:**

    - **Code Completions:**
        - Start typing a comment or code, and GitHub Copilot will provide inline suggestions.
        - Accept suggestions by pressing `Tab`.
    - **Chat:**
        - Open the Command Palette (`Cmd+Shift+P`).
        - Type "GitHub Copilot: Chat" and select it.
        - Use the chat interface to ask questions or request code snippets.
    - **Inline Chat:**
        - Highlight a piece of code.
        - Right-click and select "Ask GitHub Copilot".
        - Use the inline chat to get explanations or improvements for the selected code.

By the end of this step, you should have GitHub Copilot installed and be familiar with its basic functionality, including code completions, chat, and inline chat in Visual Studio Code.

> [!IMPORTANT]  
> Lab 1 to 5 require a GitHub Copilot Business license

## Lab 1: Exploring an Existing Codebase
Please use Copilot to explore and familiarise ourselves with the TodoAPI codebase under `src` folder

## Lab 2: Improvements and Secure Coding Practices
Now Copilot to identify potential issues with the codebase and suggest improvements. For example, we can look for potential security issues, performance improvements, or code quality enhancements.

## Lab 3: Documenting an Existing Code

Copilot can help with generating documentation for existing code which lacks comments or documentation.

1. Navigate to the `TodoItemsController.cs` file located within the `src/TodoApi/Controllers` folder.
2. Highlight the `GetTodoItems()` method, bring up the inline chat popup and use the `/docs` command to generate documentation for the method.
3. Open the Copilot Chat tab and use the `/docs` command to generate documentation for the remainder of the methods.
4. Navigate to the `DbContextExtensions.cs` file located in the `src/TodoItems/Extensions` folder.
5. Use Copilot to update the incorrect documentation to match the extension method logic.
 
## Lab 4: Generating Markdown Documentation for repository

We can also use Copilot to generate markdown documentation for our existing .NET API solution. 

When new developers start working on an existing solution, one of the first tasks they face is cloning the solution, installing the required developer dependencies and running the solution locally. A well written README.md file is a great place to give an overview of a repository and how to get started.

1. Create a new folder in the root of the repository named `docs`, within this folder create a file names `README.md`.
2. Using Copilot Chat, find out what's a good structure for a `README.md` file.
3. Using the `@workspace` agent, ask Copilot to generate the high level structure for your `README.md` file.
4. Use a combination of inline completions and inline chat to build out your `README.md` file. By the end this should have enough information for a new developer to get started with your solution.

## Lab 5: Generating Diagrams with Mermaid

GitHub Copilot can also help generate diagrams using Mermaid syntax, which can be rendered in Markdown files. This is particularly useful for visualizing complex systems, workflows, or data models.

For example, create a mermaid markdown for `PutTodoItem` under `src\TodoApi\Controllers\TodoItemsController.cs` as sequence diagram. Once saved the file as `PutTodoItem.md`, you can preview the diagram using mermaid plugin.

![Mermaid Diagram Display](res\mermaid-display.png)

> [!IMPORTANT]  
> Lab 6 to 9 require a GitHub Copilot Enterprise license

## Lab 6: Query a Repo with Copilot in GitHub.com

In this lab, we will explore how to query a repository using GitHub Copilot in the GitHub.com interface. This feature allows you to ask questions about the codebase and get insights directly from the repository.

![](res\ghcom-1.png)

![](res\ghcom-2.png)

## Lab 7: Generate a Commit or PR description with Copilot

GitHub Copilot can generate commit and pull request (PR) description. This feature helps streamline the code update process by automatically generating a description based on the changes made in the code.

![](res\prsummary.png)

## Lab 8: PR Review with Copilot

GitHub Copilot can also assist with pull request (PR) reviews. Copilot can help identify potential issues, suggest improvements, and provide insights into the code changes.

![](res\prreview.png)

## Lab 9: Building a Copilot Knowledge Base

We can build a knowledge base using GitHub Copilot. This feature allows you to create a repository of reusable code snippets, documentation, and best practices that can be easily accessed and shared within your team.

![](res\kb.png)


## Conclusion

Congratulations on completing the GitHub Copilot Lab for Leads & Architects! 

Through these hands-on exercises, you've explored how Copilot can accelerate code understanding, documentation, diagram generation, and code reviews. By leveraging Copilot’s capabilities in your workflow, you can improve productivity, enhance code quality, and onboard new team members more efficiently. 

Continue experimenting with Copilot's features to unlock even greater value in your development projects. Happy coding!


