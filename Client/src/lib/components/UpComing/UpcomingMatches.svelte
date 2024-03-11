<script lang="ts">
    const matches:any[] = [1,2,3]
</script>

<section
    data-testid="upcoming-favorites"
    class="relative z-10 h-full w-full bg-dark-grey sm:flex sm:flex-col items-center pt-4 "
  >
    <h1 class="text-2xl">Upcoming Matches</h1>
    <ul class="flex flex-col items-center sm:flex-row gap-10 pt-4">
        {#each matches as match}
            <div class="bg-light-grey size-48"></div>
        {/each}
    </ul>
</section>