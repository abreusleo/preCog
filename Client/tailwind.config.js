/** @type {import('tailwindcss').Config} */
export default {
	content: ['./src/lib/**/*.{js,ts,html,svelte}', './src/routes/**/*.{js,ts,html,svelte}'],
	theme: {
		screens: {
			sm: '640px',
			md: '768px',
			lg: '1024px',
			xl: '1280px',
			'2xl': '1536px'
		},
		extend: {
			colors: {
				'dark-grey': '#131313',
				'light-pink': '#FFC8C8',
				mauve: '#A37070',
				'light-red': '#C13434',
				'light-grey': '#323233'
			},
			fontFamily: {
				primary: ['"Reem Kufi Variable"', 'sans-serif']
			}
		}
	},
	plugins: []
};
