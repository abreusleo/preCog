<script lang="ts">
	import { Button, type Props, buttonVariants } from "$lib/components/ui/button/index";
	import { cn } from "$lib/utils";
	import type { VariantProps } from "tailwind-variants";
	import { getEmblaContext } from "./context";

	import CarouselArrow from '$lib/assets/carousel_arrow.svg';

	type $$Props = Props;

	let className: $$Props["class"] = undefined;
	export { className as class };
	export let variant: VariantProps<typeof buttonVariants>["variant"] = "outline";
	export let size: VariantProps<typeof buttonVariants>["size"] = "icon";
	const { orientation, canScrollNext, scrollNext, handleKeyDown } =
		getEmblaContext("<Carousel.Next/>");
</script>

<Button
	{variant}
	{size}
	class={cn(
		"absolute w-6",
		$orientation === "horizontal"
			? "-right-12 top-1/2 -translate-y-1/2"
			: "-bottom-12 left-1/2 -translate-x-1/2 rotate-180 border-none",
		className
	)}
	disabled={!$canScrollNext}
	on:click={scrollNext}
	on:keydown={handleKeyDown}
	{...$$restProps}
>
	<img src={CarouselArrow} alt="Up arrow" class="h-auto w-max shadow-black drop-shadow-lg " />
</Button>
