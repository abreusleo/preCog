# Main idea

We want to predict the match/tournament winner based on compositions, maps, players and performance.

## Data

As you know, we require a massive amount of data to accurately predict match results, and this poses a significant challenge as there's no public API available to access the necessary information

We're facing this challenge, and there's a common approach called Web scraping. We're considering two possibilities to implement it: RPA or Python with Scrapy.

### UiPath

Pros
- Simple
- Easier to update and maintain
- Bessa’s knowledge

Couns

- We don’t know how a RPA project works on a dynamic solution
- Everyone else, except for Bessa, lack of knowledge

### Python

Pros

- Easier to update and maintain
- We know this project would work on our stack
- Everyone knows how to code in Python

Couns

- Dynamic scraping might be a problem

Stack

- App (Front-end) - React (Next.js) or Svelte
- Api - .NET
- Scraping Service - Uipath or Python (RPA)
- Prediction Service (Python)
- RabbitMQ - Services communication
- DB

