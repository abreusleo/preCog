<script lang="ts">
  import type { Championship, Player, Team } from '$lib/interfaces/dataTypes';
  import Carousel from '../Carousel/CarouselMenu.svelte';
  import PredictionSelection from './PredictionSelection.svelte';
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
  class="relative z-10 flex h-full w-full flex-col items-center pb-24 pt-8 sm:my-12 sm:h-[30rem] sm:w-[90%] md:w-[85%] sm:flex-row sm:rounded-lg sm:bg-dark-grey sm:p-0 "
>
  <div class="flex flex-col w-full items-center sm:mb-[8rem]">
    <h1
      class="mb-[0.4rem] pt-4 flex w-full items-center justify-center font-primary text-2xl text-light-pink"
    >
      Prediction type
    </h1>
    <hr class="mb-24 w-16 border-light-pink bg-light-pink" />
    <div class="flex h-20 w-full flex-col items-center justify-center">
      <Carousel/>
    </div>
  </div>
  <hr class="sm:h-16 sm:w-1 border-light-pink bg-light-pink m-20 sm:m-0">
  <PredictionSelection activeType={activeType} data={data}/>
</section>
