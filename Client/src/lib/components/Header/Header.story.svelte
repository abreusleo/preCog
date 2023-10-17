<script lang="ts">
  import type { Hst } from '@histoire/plugin-svelte';

  import { Header } from '.';
  import Menu from '../Menu/Menu.story.svelte';

  export let Hst: Hst;

  let menuOpen = false;
  let menuClosing = false;
  let headerButtonFadingOut = false;
  let headerButtonVisible = true;

  function toggleMenuOpen() {
    if (menuOpen) {
      menuClosing = true;

      setTimeout(() => {
        menuClosing = false;
        menuOpen = false;
        headerButtonVisible = true;
      }, 350);
    } else {
      menuOpen = true;
      headerButtonFadingOut = true;
      setTimeout(() => {
        headerButtonFadingOut = false;
        headerButtonVisible = false;
      }, 350);
    }
  }
</script>

<svelte:component this={Hst.Story}>
  <Header {headerButtonFadingOut} {headerButtonVisible} {toggleMenuOpen} />
</svelte:component>
