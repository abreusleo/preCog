<script lang="ts">
  import type { Hst } from '@histoire/plugin-svelte';
  import { Header } from '.';

  export let Hst: Hst;
</script>

<svelte:component this={Hst.Story}>
  <Header />
</svelte:component>
