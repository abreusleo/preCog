<script lang="ts">
  import type { Hst } from '@histoire/plugin-svelte';

  import { Menu } from '.';

  export let Hst: Hst;
</script>

<svelte:component this={Hst.Story} title="Menu">
  <svelte:component this={Hst.Variant}>
    <Menu />
    <svelte:fragment slot="controls"></svelte:fragment>
  </svelte:component>
</svelte:component>
