<script lang="ts">
  import Logo from '$lib/assets/precoglogo.svg';

  export let headerButtonFadingOut = false;
  export let headerButtonVisible = true;
  export let toggleMenuOpen = () => {null};

  $: fadeOutHeaderButton = headerButtonFadingOut ? 'animate-fade-out-header-button ' : ' ';
  $: fadeInHeaderButton = headerButtonVisible ? 'animate-fade-in-header-button block ' : 'hidden ';
</script>

<div
  class="fixed left-0 top-0 z-40 flex h-16 w-full items-center justify-between bg-dark-grey px-4 shadow-md shadow-black"
>
  <img src={Logo} alt="PreCog logo" />
  <div class="flex gap-4">
    <button
      class="flex h-12 w-28 items-center justify-center rounded-md bg-dark-grey font-primary text-base text-light-pink border border-gray-600"
    >
      SIGN IN
    </button>
    <button on:click={toggleMenuOpen}>
      <span
        class={fadeOutHeaderButton +
          fadeInHeaderButton +
          'mb-1 h-1 w-auto rounded-full border-[2.5px] border-light-pink'}
      />
      <span
        class={fadeOutHeaderButton +
          fadeInHeaderButton +
          'mb-1 h-1 w-auto rounded-full border-[2.5px] border-light-pink [animation-delay:100ms]'}
      />
      <span
        class={fadeOutHeaderButton +
          fadeInHeaderButton +
          'h-1 w-auto rounded-full border-[2.5px] border-light-pink [animation-delay:200ms]'}
      />
    </button>
  </div>
</div>
