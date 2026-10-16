# FoodieHub

FoodieHub is a Blazor-based recipe and community app built for discovering, sharing, and reviewing food ideas. The project combines a modern C# server-side web app with Tailwind CSS styling to deliver a clean, responsive experience.

## Features

- User login and account registration
- Recipe dashboard with category filtering
- Recipe creation form for users to publish dishes
- Review and rating system for each recipe
- Favorite tracking for saved recipes
- Responsive, mobile-friendly layout using Tailwind CSS

## Tech Stack

- ASP.NET Core / Blazor
- C#
- Tailwind CSS
- HTML/CSS/JavaScript

## Project Structure

- `Components` - Blazor pages and UI components
- `Models` - Data models for users, recipes, cuisines, and reviews
- `Services` - Authentication and recipe logic
- `wwwroot` - static assets and generated CSS
- `tailwind.config.js` - Tailwind configuration

## Run locally

1. Open a terminal in the project folder.
2. Restore dependencies:
   ```bash
   dotnet restore
   npm install
   ```
3. Build Tailwind styles:
   ```bash
   npm run build:css
   ```
4. Start the app:
   ```bash
   dotnet watch run
   ```
5. Open the app in a browser at:
   ```text
   http://localhost:5005
   ```

## Demo login

- Email: `demo@foodiehub.com`
- Password: `password123`

## Notes

This project is intended as a Blazor learning and development app for recipe-sharing functionality and front-end experimentation with Tailwind CSS.
