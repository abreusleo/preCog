<script lang="ts">
  import Logo from '$lib/assets/precoglogo.svg';
  import Modal from '../Modal/Modal.svelte';
  import Menu from "../Menu/Menu.svelte"

  export let menuOpen = false;
  export let menuClosing = false;
  export let headerButtonFadingOut = false;
  export let headerButtonVisible = true;
  export let hiddenMenu = false;

  let showLoginModal = false;
  let showRegisterModal = false;
  let closeLoginModal: VoidFunction;
  let closeRegisterModal: VoidFunction;


  function onCloseModal(){
    closeRegisterModal();
    openLoginModal();
  }

  function openLoginModal() {
    showLoginModal = !showLoginModal;
  }

  function openRegisterModal() {
    if (showLoginModal){
      showLoginModal = false;
      closeLoginModal();
    }
    showRegisterModal = !showRegisterModal;
  }

  function showConfirmationPasswordModal() {
    let email = document.getElementById("emailRegister") as HTMLInputElement;
    let username = document.getElementById("usernameRegister") as HTMLInputElement;
    if (email != null && email.value && username != null && username.value) {
      showElementById("confirmationPasswordModal");
      hideElementById("emailUsernameModal");
    }
  }

  function backToEmailUsernameModal() {
    hideElementById("confirmationPasswordModal");
    showElementById("emailUsernameModal");
  }

  function showElementById(id: string) {
    let element = document.getElementById(id);
    if (element != null) {
      element.style.display = "block";
    }
  }

  function hideElementById(id: string) {
    let element = document.getElementById(id);
    if (element != null) {
      element.style.display = "none";
    }
  }

  function onSubmit(e: any) {
    const formData = new FormData(e.target);

    const data = {} as any;
    for (let field of formData) {
      const [key, value] = field;
      data[key] = value;
    }
    console.log(data)
  }

  $: fadeOutHeaderButton = headerButtonFadingOut ? 'animate-fade-out-header-button ' : ' ';
  $: fadeInHeaderButton = headerButtonVisible ? 'animate-fade-in-header-button block ' : 'hidden';
  $: hidden = hiddenMenu ? 'cursor-default' : '';

  let menuIsOpening = false;

  export function menuToggle(){
    if(menuIsOpening) {
      return
    }
    menuIsOpening = true;
    setTimeout(() => {
      menuIsOpening = false;
    }, 500);

    headerButtonVisible = !headerButtonVisible;
    headerButtonFadingOut = !headerButtonFadingOut;
    hiddenMenu = !hiddenMenu;
    menuOpen = !menuOpen;
    menuClosing = !menuClosing;
  }
</script>

<div
  class="fixed left-0 top-0 z-40 flex h-16 w-full items-center justify-between bg-dark-grey px-4 shadow-md shadow-black md:px-10 "
>
  <img src={Logo} alt="PreCog logo" />
  <div class="flex gap-4">
    <button
      class="flex h-12 w-28 items-center justify-center rounded-md bg-dark-grey font-primary text-base text-light-pink border border-gray-600 hidden-mobile"
      on:click={openLoginModal}
    >
      SIGN IN
    </button>
    <button class={hidden +" sm:hidden flex flex-col items-center justify-between w-5"} on:click={menuToggle}>
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

<Modal bind:showModal="{showLoginModal}" bind:closeModal={closeLoginModal}>
  <div slot="body" class="grid grid-cols-1 content-center">
    <form on:submit|preventDefault={onSubmit}>
      <div class="m-5">
        <label for="usernameLogin" class="text-xl">Username</label>
        <input type="text" name="usernameLogin" id="usernameLogin" class="bg-black text-white text-sm rounded-lg focus:outline-none focus:ring-1 focus:ring-red-500 block w-full p-2.5" required>
      </div>
      <div class="m-5">
        <label for="passwordLogin" class="text-xl">Password</label>
        <input type="password" name="passwordLogin" id="passwordLogin" class="bg-black text-white text-sm rounded-lg focus:outline-none focus:ring-1 focus:ring-red-500 block w-full p-2.5" required>
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
        Don't have an account? &nbsp;<button class="underline text-red-700" on:click={openRegisterModal}>Sign up</button>
    </div>
  </div>
</Modal>

<Modal bind:showModal="{showRegisterModal}" bind:closeModal={closeRegisterModal}>
  <div slot="body" class="grid grid-cols-1 content-center">
    <form on:submit|preventDefault={onSubmit}>
      <div id="emailUsernameModal">
        <div class="m-5">
          <label for="emailRegister" class="text-xl">Email</label>
          <input type="email" name="emailRegister" id="emailRegister" class="bg-black text-white text-sm rounded-lg focus:outline-none focus:ring-1 focus:ring-red-500 block w-full p-2.5" required>
        </div>
        <div class="m-5">
          <label for="usernameRegister" class="text-xl">Username</label>
          <input type="text" name="usernameRegister" id="usernameRegister" class="bg-black text-white text-sm rounded-lg focus:outline-none focus:ring-1 focus:ring-red-500 block w-full p-2.5" required>
        </div>
        <div class="m-5">
          <button
            name="nextButton"
            type="button"
            class="h-12 w-28 rounded-md bg-red-500 font-primary text-sm text-light-pink"
            on:click={showConfirmationPasswordModal}
          >
            NEXT
          </button>
        </div>
      </div>
      <div id="confirmationPasswordModal" class="hidden">
        <div id="backButton">
          <button 
            name="backButton"
            type="button" 
            class="w-full flex flex-row py-2 font-primary text-sm text-light-pink transition-colors duration-200 gap-x-2 sm:w-auto"
            on:click={backToEmailUsernameModal}
          >
            <svg class="w-5 h-5 rtl:rotate-180" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" d="M6.75 15.75L3 12m0 0l3.75-3.75M3 12h18" />
            </svg>
            <span>Back</span>
          </button>
        </div>
        <div id="passwordInput" class="m-5">
          <label for="passwordRegister" class="text-xl">Password</label>
          <input type="password" name="passwordRegister" id="passwordRegister" class="bg-black text-white text-sm rounded-lg focus:outline-none focus:ring-1 focus:ring-red-500 block w-full p-2.5" required>
        </div>
        <div id="confirmationPasswordInput" class="m-5">
          <label for="passwordConfirmationRegister" class="text-xl">Confirm Password</label>
          <input type="password" name="passwordConfirmationRegister" id="passwordConfirmationRegister" class="bg-black text-white text-sm rounded-lg focus:outline-none focus:ring-1 focus:ring-red-500 block w-full p-2.5" required>
        </div>
        <div id="registerButton" class="m-5">
          <button
            type="submit"
            class="h-12 w-28 rounded-md bg-red-500 font-primary text-sm text-light-pink"
          >
            REGISTER
          </button>
        </div>
      </div>
    </form>
  </div>
  <div slot="footer">
    <div class="font-primary text-sm text-light-pink">
        Already have an account? &nbsp;<button class="underline text-red-700" on:click={onCloseModal}>Sign in</button>
    </div>
  </div>
</Modal>
<Menu {menuOpen} {menuClosing} {menuToggle} {openLoginModal}/>

<style>
  @media (max-width: 640px) {
    .hidden-mobile {
      display: none;
    }
  }
</style>