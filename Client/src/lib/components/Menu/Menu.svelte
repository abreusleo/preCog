<script lang='ts'>
  export let menuToggle: () => void
  export let menuOpen: boolean;
  export let menuClosing: boolean;
  // export let menuIsOpening: boolean;
  // export let menuIsClosing: boolean;

  import CloseMenuArrow from '$lib/assets/page_scroll_arrow.svg';
    $: menuExpand = menuOpen ? 'animate-expand-menu flex' : 'hidden';
    $: menuCollapse = menuClosing ? 'animate-collapse-menu' : '';


    function togglePrediction() {
      console.log("return")
    }
</script>

<div
  class={menuExpand +
    menuCollapse +
    ' sm:invisible z-20 fixed right-0 top-0 h-52 w-40 origin-top  rounded-l-lg bg-dark-grey pt-16 shadow-md shadow-black '}
>
  <div class="flex h-full w-full flex-col items-center justify-around">
    <button
      class="w-fit font-primary text-sm font-light text-light-pink transition-colors duration-300 cursor-pointer hover:text-white"  on:click={togglePrediction}
    >
      MY PREDICTIONS
    </button>
    <button
      class="w-fit font-primary text-sm font-light text-light-pink transition-colors duration-300 hover:cursor-pointer hover:text-white" on:click={togglePrediction}
    >
      LOG OUT
    </button>
    <button class="flex h-fit w-5 items-center justify-center left-52" on:click={menuToggle}>
      <img
        src={CloseMenuArrow}
        alt="Up arrow"
        class="h-auto w-max rotate-180 shadow-black drop-shadow-lg"
      />
    </button>
  </div>
</div>

<style>
  .transition-show {
  opacity: 1;
  visibility: visible;
  transition: opacity 0.3s ease-in-out, visibility 0.3s ease-in-out;
}

.transition-hide {
  opacity: 0;
  visibility: hidden;
  transition: opacity 0.6s ease-in-out, visibility 0.6s ease-in-out;
}
</style>
