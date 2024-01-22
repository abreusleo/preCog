<script lang="ts">
  import type { Hst } from '@histoire/plugin-svelte';

  import { Menu } from '.';
  export let menuOpen: boolean
  export let menuClosing: boolean

  let Hst: Hst;
</script>

<svelte:component this={Hst.Story} title="Menu">
  <svelte:component this={Hst.Variant}>
    <Menu {menuOpen} {menuClosing}/>
    <svelte:fragment slot="controls"></svelte:fragment>
  </svelte:component>
</svelte:component>
