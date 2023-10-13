<script lang="ts">
  import CarouselArrow from '$lib/assets/carousel_arrow.svg';
  import { PredictionTypes } from '$lib/interfaces/predictionTypes';

  let predictionTypes: string[] = [PredictionTypes[0], PredictionTypes[1], PredictionTypes[2]];
  let carouselIsMoving: boolean = false;

  function handleCarouselClick(array: string[], index: number) {
    if (carouselIsMoving) return;

    array.push(array[0]);
    carouselIsMoving = true;
    setTimeout(() => {
      carouselIsMoving = false;
    }, 200);
  }

  $: carouselItemAnimation = carouselIsMoving ? 'animate-slideup ' : '';
</script>

<div class="flex w-max flex-col items-center">
  <button class="mb-1 flex h-fit w-6 items-center justify-center">
    <img src={CarouselArrow} alt="Up arrow" class="h-auto w-max shadow-black drop-shadow-lg" />
  </button>
  <div class="flex flex-col items-center">
    {#each predictionTypes as type, i}
      {#if i === 1}
        <span
          class="my-1 font-primary text-lg font-semibold text-light-pink [text-shadow:2px_2px_4px_black]"
        >
          {type}
        </span>
      {:else}
        <span class="font-primary text-xs text-light-pink/20">{type}</span>
      {/if}
    {/each}
  </div>
  <button class="mt-1 flex h-fit w-6 items-center justify-center">
    <img
      src={CarouselArrow}
      alt="Down arrow"
      class="h-auto w-max rotate-180 shadow-black drop-shadow-lg"
    />
  </button>
</div>
