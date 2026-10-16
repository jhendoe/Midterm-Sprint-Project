module.exports = {
  content: [
    "./Components/**/*.{razor,html}",
    "./**/*.razor",
    "./**/*.cshtml",
    "./wwwroot/**/*.html",
    "./wwwroot/**/*.js"
  ],
  theme: {
    extend: {
      colors: {
        cream: "#FFF8F0",
        tomato: "#E4572E",
        basil: "#3F7D58",
        charcoal: "#2B2B2B"
      },
      fontFamily: {
        display: ["Fraunces", "serif"],
        sans: ["Inter", "system-ui", "sans-serif"]
      }
    }
  },
  plugins: []
};

