/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
  theme: {
    extend: {
      fontFamily: {
        // Add 'prompt' and fallback to sans
        prompt: ['"Prompt"', ...defaultTheme.fontFamily.sans],
      },
    },
  },
  plugins: [],
};
