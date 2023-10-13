<script lang="ts">
  import BackgroundImg from '$lib/assets/valorant-4.jpg';
  import PredictionContainer from '$lib/components/PredictionContainer.svelte';
</script>

<main class="h-screen">
  <div class="z-0 fixed left-0 top-14 h-screen w-full overflow-hidden">
    <div class="fixed h-screen opacity-5">
      <img
        src={BackgroundImg}
        alt="Omen background"
        class="fixed h-full w-auto object-cover"
        width="2560"
        height="1440"
      />
    </div>
  </div>
  <PredictionContainer />
</main>
