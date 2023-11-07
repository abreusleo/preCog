<script lang="ts">
  import { Carousel } from './Carousel';
  import PredictionSelection from './PredictionSelection.svelte';
  import DownScroll from '$lib/assets/page_scroll_arrow.svg';
</script>

<section
  data-testid="predictions"
  class="relative z-10 flex h-full w-full flex-col justify-between pb-24 pt-8 sm:my-12 sm:h-[30rem] sm:w-[70%] sm:flex-row sm:rounded-lg sm:bg-dark-grey sm:p-0"
>
  <!-- <div class="flex w-full flex-col items-center sm:flex-row">
    <div class='flex flex-col items-center'>
      <h1
        class="mb-[0.4rem] flex w-full items-center justify-center font-primary text-lg text-light-pink"
      >
        Prediction type
      </h1>
      <hr class="border-1 mb-6 w-16 border-light-pink bg-light-pink" />
      <Carousel />
    </div>
    <PredictionSelection />
    <hr class="border-1 mb-6 w-16 border-light-pink bg-light-pink sm:hidden" />
  </div>
  <div class="flex w-full justify-center">
    <img src={DownScroll} alt="Down arrow" class="h-auto w-max shadow-black drop-shadow-lg sm:hidden" />
  </div> -->
</section>
