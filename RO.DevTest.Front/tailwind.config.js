/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx}",
    "./components/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        brand: {
          background: '#F4F4F5',
          panel: '#E5E5E5',
          primary: '#2563EB',
          hover: '#1D4ED8',
          text: '#111827',
        },
      },
    },
  },
  plugins: [],
}
