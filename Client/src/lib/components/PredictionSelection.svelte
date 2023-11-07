<script lang="ts">
  import type { Championship, Player, Team } from '$lib/interfaces/dataTypes';

  export let activeType: string;

  export let data: {
    types: string[];
    championships: Championship[];
    players: Player[];
    teams: Team[];
  };

  function handleClick(activeType: string) {
    const teamInput = {
      FirstTeam: data.teams[0].name,
      SecondTeam: data.teams[1].name
    };

    const championshipInput = {
      Name: data.championships[0].name
    };

    if (activeType === 'Teams') fetch(`http://localhost:4001/Prediction?type=Teams`, {
      method: 'POST',
      body: JSON.stringify(teamInput),
      mode: 'no-cors',
      headers: {
        'content-type': 'text/plain',
        'accept': '*/*'
      }
    });
  }
</script>

<div
  class="mb-5 mt-10 flex h-64 w-[85%] flex-col items-center justify-between rounded-md bg-prediction-container-grey p-6 shadow-lg"
>
  <div class="flex w-full items-center justify-between">
    {#if activeType === 'Players'}
      <div class='flex flex-col items-center'>
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img src={data.players[0].photoUrl} alt='Player 1' class='h-full w-full rounded-md shadow-lg'>
        </div>
        {data.players[0].name}
      </div>
      <span class='font-primary text-light-red text-lg'>
        X
      </span>
      <div class='flex flex-col items-center'>
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img src={data.players[1].photoUrl} alt='Player 1' class='h-full w-full rounded-md shadow-lg'>
        </div>
        {data.players[1].name}
      </div>
    {/if}
    {#if activeType === 'Teams'}
      <div class='flex flex-col items-center'>
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img src={data.teams[0].logoUrl} alt='Player 1' class='h-full w-full rounded-md shadow-lg'>
        </div>
        {data.teams[0].name}
      </div>
      <span class='font-primary text-light-red text-lg'>
        X
      </span>
      <div class='flex flex-col items-center'>
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img src={data.teams[1].logoUrl} alt='Player 1' class='h-full w-full rounded-md shadow-lg'>
        </div>
        {data.teams[1].name}
      </div>
    {/if}
    {#if activeType === 'Championships'}
      <div class='flex flex-col items-center'>
        <div class="mb-3 h-16 w-16 rounded-md bg-grey">
          <img src={data.championships[0].logoUrl} alt='Player 1' class='h-full w-full rounded-md shadow-lg'>
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
