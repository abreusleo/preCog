<script lang="ts">
  import Logo from '$lib/assets/precoglogo.svg';
  import Modal from '../Modal/Modal.svelte';

  export let headerButtonFadingOut = false;
  export let headerButtonVisible = true;
  export let toggleMenuOpen = () => {null};

  let showModal = false;

  function toggleModalOpen() {
    showModal = true;
  }

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
      on:click={toggleModalOpen}
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

<Modal bind:showModal>
  <div slot="body" class="grid grid-cols-1 content-center">
    <form>
      <div class="m-5">
        <label for="username" class="text-xl">Username</label>
        <input type="text" id="username" class="bg-black text-white text-sm rounded-lg focus:outline-none focus:ring-1 focus:ring-red-500 block w-full p-2.5" required>
      </div>
      <div class="m-5">
        <label for="password" class="text-xl">Password</label>
        <input type="password" name="password" id="password" class="bg-black text-white text-sm rounded-lg focus:outline-none focus:ring-1 focus:ring-red-500 block w-full p-2.5" required>
      </div>
      <div class="m-5">
        <button
          class="h-12 w-28 rounded-md bg-red-500 font-primary text-sm text-light-pink"
        >
          ENTER
        </button>
      </div>
    </form>
  </div>
  <div slot="footer">
    <div class="font-primary text-sm text-light-pink">
        Don't have an account? &nbsp;<a class="underline text-red-700" href="">Sign Up</a>
    </div>
  </div>
</Modal>
