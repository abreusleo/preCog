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
        'light-grey': '#323233',
        grey: '#232323',
        'prediction-container-grey': '#171717'
      },
      fontFamily: {
        primary: ['"Reem Kufi Variable"', 'sans-serif']
      },
      animation: {
        'expand-menu': 'expandY 0.4s ease-in-out',
        'collapse-menu': 'collapseY 0.4s ease-in-out',
        'fade-out-header-button': 'fadeOut 0.4s forwards',
        'fade-in-header-button': 'fadeIn 0.4s forwards'
      },
      keyframes: {
        expandY: {
          from: { transform: 'scale(1, 0)' },
          to: { transform: 'scale(1, 1)' }
        },
        collapseY: {
          from: { transform: 'scale(1, 1)' },
          to: { transform: 'scale(1, 0)' }
        },
        fadeOut: {
          from: { opacity: 1 },
          to: { opacity: 0 }
        },
        fadeIn: {
          from: { opacity: 0 },
          to: { opacity: 1 }
        }
      }
    }
  },
  plugins: []
};
