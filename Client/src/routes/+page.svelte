<script lang="ts">
  import BackgroundImg from '$lib/assets/valorant-4.jpg';
  import { PredictionContainer } from '$lib/components/PredictionContainer/index.js';
  import UpcomingMatches from '$lib/components/UpComing/UpcomingMatches.svelte';
  import type { Championship, Player, Team } from '$lib/interfaces/dataTypes';
  export let data: {
    types: string[];
    championships: Championship[];
    players: Player[];
    teams: Team[];
  };
</script>

<main class="flex h-screen flex-col items-center pt-16">
  <div class="fixed left-0 top-14 z-0 h-screen w-full overflow-hidden">
    <div class="fixed h-screen opacity-5 sm:opacity-100">
      <img
        src={BackgroundImg}
        alt="Omen background"
        class="fixed h-full w-auto object-cover sm:w-full"
        width="2560"
        height="1440"
      />
    </div>
  </div>

  <PredictionContainer data={data}/>
   <UpcomingMatches/>
</main>
