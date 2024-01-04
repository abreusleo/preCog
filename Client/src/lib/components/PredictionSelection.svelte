<script lang="ts">
  import type { Championship, Player, Team } from '$lib/interfaces/dataTypes';

  export let activeType: string;

  export let data: {
    types: string[];
    championships: Championship[];
    players: Player[];
    teams: Team[];
  };

  async function handleClick(activeType: string) {
    const teamInput = {
      FirstTeamId: data.teams[0].id,
      SecondTeamId: data.teams[1].id
    };

    const championshipInput = {
      Id: data.championships[0].id
    };

    const playerInput = {
      FirstPlayerId: data.players[0].id,
      SecondPlayerId: data.players[1].id
    };

    if (activeType === 'Teams') {
      const response = await fetch(`http://localhost:8080/api/Prediction?type=1`, {
        method: 'POST',
        body: JSON.stringify(teamInput),
        headers: {
          "Content-Type": "application/json"
        }
      });

      console.log(response);
    }
    if (activeType === 'Championships') {
      const response = await fetch(`http://localhost:8080/api/Prediction?type=2`, {
        method: 'POST',
        body: JSON.stringify(championshipInput),
        headers: {
          "Content-Type": "application/json"
        }
      });

      console.log(response);
    }
    if (activeType === 'Players') {
      const response = await fetch(`http://localhost:8080/api/Prediction?type=0`, {
        method: 'POST',
        body: JSON.stringify(playerInput),
        headers: {
          "Content-Type": "application/json"
        }
      });

      console.log(response);
    }
  }
</script>

<div
  class="mb-5 mt-10 flex h-64 w-[85%] flex-col items-center justify-between rounded-md bg-prediction-container-grey p-6 shadow-lg"
>
  <div class="flex w-full items-center justify-between">
    {#if activeType === 'Players'}
      <div class="flex flex-col items-center">
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img
            src={data.players[0].photoUrl}
            alt="Player 1"
            class="h-full w-full rounded-md shadow-lg"
          />
        </div>
        {data.players[0].name}
      </div>
      <span class="font-primary text-lg text-light-red">X</span>
      <div class="flex flex-col items-center"> 
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img
            src={data.players[1].photoUrl}
            alt="Player 1"
            class="h-full w-full rounded-md shadow-lg"
          />
        </div>
        {data.players[1].name}
      </div>
    {/if}
    {#if activeType === 'Teams'}
      <div class="flex flex-col items-center">
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img
            src={data.teams[0].logoUrl}
            alt="Player 1"
            class="h-full w-full rounded-md shadow-lg"
          />
        </div>
        {data.teams[0].name}
      </div>
      <span class="font-primary text-lg text-light-red">X</span>
      <div class="flex flex-col items-center">
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img
            src={data.teams[1].logoUrl}
            alt="Player 1"
            class="h-full w-full rounded-md shadow-lg"
          />
        </div>
        {data.teams[1].name}
      </div>
    {/if}
    {#if activeType === 'Championships'}
      <div class="flex flex-col items-center">
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img
            src={data.championships[0].logoUrl}
            alt="Player 1"
            class="h-full w-full rounded-md shadow-lg"
          />
        </div>
        {data.championships[0].name}
      </div>
    {/if}
  </div>
  <button
    class="flex h-12 w-28 items-center justify-center rounded-md bg-red-500 font-primary text-sm text-light-pink"
    on:click={() => handleClick(activeType)}
  >
    PREDICT
  </button>
</div>
