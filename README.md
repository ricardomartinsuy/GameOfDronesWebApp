# Game Of Drones Project

Welcome to the Game Of Drones project! This project is a web application designed for managing drone operations. It is composed of three main parts: **API**: Located in the `GameOfDronesWebApp` folder. **Tests**: Located in the `GameOfDrones.Tests` folder. **Frontend**: An Angular application located in the `GameOfDronesFront` folder.

## Features

- Start a new game between two players.
- Play rounds within an ongoing game.
- Retrieve details for specific games or individual rounds.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Running the API](#running-the-api)
- [Endpoints](#api-endpoints)
- [Running the Tests](#running-the-tests)
- [Running the Angular Frontend](#running-the-angular-frontend)
- [Conclusion](#conclusion)

## Prerequisites

Before running the project, ensure you have the following software installed on your machine: - [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (ensure you have a version compatible with the API) - [Node.js](https://nodejs.org/) (for running Angular) - [Angular CLI](https://angular.io/cli) (install globally using npm)

To install Angular CLI globally, run the following command:

```bash
npm install -g @angular/cli
```

## Running the API

To run the API located in the `GameOfDronesWebApp` folder, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the `GameOfDronesWebApp` directory:

   ```bash
   cd GameOfDronesWebApp
   ```

3. Restore the project dependencies:

   ```bash
   dotnet restore
   ```

4. Run the API:

   ```bash
   dotnet run
   ```

   The API will start running on `http://localhost:5000` (or another port specified in your configuration).

# API Endpoints

## Game Management
* **Start a New Game**
  * **Endpoint:** `/api/game/start`
  * **Method:** POST
  * **Request Body:**
    ```json
    {
      "player1": { "name": "Player1" },
      "player2": { "name": "Player2" }
    }
    ```
  * **Response:** 201 Created with game details.

## Game Play
* **Play a Round**
  * **Endpoint:** `/api/game/play/{gameId}`
  * **Method:** POST
  * **Parameters:**
    * `gameId` (int): The unique game ID.
  * **Request Body:**
    ```json
    {
      "player1Move": "Rock",
      "player2Move": "Paper"
    }
    ```
  * **Response:** 201 Created with round result.

## Game Information
* **Get Game Details**
  * **Endpoint:** `/api/game/{id}`
  * **Method:** GET
  * **Parameters:**
    * `id` (int): The game ID.
  * **Response:**
    * 200 OK with game details
    * 404 Not Found if the game doesn't exist.
* **Get Round Details**
  * **Endpoint:** `/api/game/round/{id}`
  * **Method:** GET
  * **Parameters:**
    * `id` (int): The round ID.
  * **Response:**
    * 200 OK with round details
    * 404 Not Found if the round doesn't exist.

## Running the Tests

To run the unit tests located in the `GameOfDrones.Tests` folder, perform the following steps:

1. Open a terminal or command prompt.
2. Navigate to the `GameOfDrones.Tests` directory:

   ```bash
   cd GameOfDrones.Tests
   ```

3. Run the tests:

   ```bash
   dotnet test
   ```

   This command will execute all the tests defined in the project and display the results in the terminal.

## Running the Angular Frontend

To run the Angular application located in the `GameOfDronesFront` folder, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the `GameOfDronesFront` directory:

   ```bash
   cd GameOfDronesFront
   ```

3. Install the required packages:

   ```bash
   npm install
   ```

4. Start the Angular development server:

   ```bash
   ng serve
   ```

   The Angular application will be available at `http://localhost:4200`.

## Conclusion

You can now interact with the API, run tests, and explore the Angular frontend of the Game Of Drones project. For any issues or further assistance, please refer to the respective documentation for .NET and Angular, or reach out to the project maintainers.

Happy coding!
