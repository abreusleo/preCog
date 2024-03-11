<script lang="ts">
  import { PredictionTypes } from '$lib/interfaces/predictionTypes';
  import * as Carousel from "$lib/components/ui/carousel/index";
    import type { CarouselAPI } from "$lib/components/ui/carousel/context";

  let predictionTypes: string[] = [PredictionTypes[0], PredictionTypes[1], PredictionTypes[2]];
  let api: CarouselAPI;
  let count = 0;
  let current = 0;

  $: if (api) {
    count = api.scrollSnapList().length;
    current = api.selectedScrollSnap();
    api.on("select", () => {
      current = api.selectedScrollSnap();
    });
    console.log(current, count)
  }
</script>

<div class="flex w-max flex-col items-center justify-center">
  <Carousel.Root
    opts={{
      align: "start"
    }}
    orientation="vertical"
    class="w-full max-w-sm h-[100px] flex items-center"
    bind:api
  >
    <Carousel.Content class="-mt-1 h-[50px]">
      {#each predictionTypes as type, i}
      <Carousel.Item class="pt-1 md:basis-1/3 lg:basis-1/3 flex items-center justify-center">
        {#if current == i}
           <span
            class="my-1 font-primary text-lg font-semibold text-light-pink [text-shadow:2px_2px_4px_black] sm:text-3xl"
          >
            {type} {i}
          </span>
          {:else}
          <span class="my-1 font-primary text-xs text-light-pink/20 sm:text-3xl">{type} </span>
          {/if}
        </Carousel.Item>
      {/each}
    </Carousel.Content>
    <Carousel.Previous />
    <Carousel.Next />
  </Carousel.Root>
</div>
