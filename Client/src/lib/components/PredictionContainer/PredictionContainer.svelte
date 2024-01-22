<script lang="ts">
  import type { Championship, Player, Team } from '$lib/interfaces/dataTypes';
  import PredictionSelection from '../PredictionSelection.svelte';

  export let data: {
    types: string[];
    championships: Championship[];
    players: Player[];
    teams: Team[];
  };

  let activeType: string;

  let types = data.types;
</script>

<section
  data-testid="predictions"
  class="relative z-10 flex h-full w-full flex-col justify-between pb-24 pt-8 sm:my-12 sm:h-[30rem] sm:w-[70%] sm:flex-row sm:rounded-lg sm:bg-dark-grey sm:p-0"
>
  <div class="mb-10 flex w-full flex-col items-center">
    <h1
      class="mb-[0.4rem] flex w-full items-center justify-center font-primary text-lg text-light-pink"
    >
      Prediction type
    </h1>
    <hr class="border-1 mb-6 w-16 border-light-pink bg-light-pink" />
    <div class="flex h-20 w-full flex-col items-center justify-center">
      <select
        bind:value={activeType}
        class="mb-8 h-8 w-20 rounded-lg border-2 border-light-pink bg-black"
      >
        {#each types as type, i}
          <option value={type}>
            {type}
          </option>
        {/each}
      </select>
    </div>
    <PredictionSelection activeType={activeType} data={data}/>
  </div>
</section>
