<script lang="ts">
  import type { Hst } from '@histoire/plugin-svelte';

  import { Menu } from '.';

  let Hst: Hst;
</script>

<Hst.Story title="Menu">
  <svelte:component this={Hst.Variant}>
    <Menu />
    <svelte:fragment slot="controls"></svelte:fragment>
  </svelte:component>
</Hst.Story>
