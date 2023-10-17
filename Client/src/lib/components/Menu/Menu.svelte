<script lang="ts">
  import CloseMenuArrow from '$lib/assets/page_scroll_arrow.svg';

  export let menuOpen = false;
  export let menuClosing = false;

  $: menuExpand = menuOpen ? 'animate-expand-menu flex ' : 'hidden ';
  $: menuCollapse = menuClosing ? 'animate-collapse-menu ' : ' ';
</script>

<div
  class={menuExpand +
    menuCollapse +
    'fixed right-0 top-0 h-56 w-40 origin-top flex-col items-center justify-evenly rounded-l-lg bg-dark-grey pb-3 pt-16 shadow-md shadow-black'}
>
  <div class="flex h-full w-full flex-col items-center justify-evenly">
    <div
      class="w-fit font-primary text-sm font-light text-light-pink transition-colors duration-300 hover:cursor-pointer hover:text-white"
    >
      MY PREDICTIONS
    </div>
    <div
      class="w-fit font-primary text-sm font-light text-light-pink transition-colors duration-300 hover:cursor-pointer hover:text-white"
    >
      LOG OUT
    </div>
  </div>
  <button class="flex h-fit w-5 items-center justify-center">
    <img
      src={CloseMenuArrow}
      alt="Up arrow"
      class="h-auto w-max rotate-180 shadow-black drop-shadow-lg"
    />
  </button>
</div>
