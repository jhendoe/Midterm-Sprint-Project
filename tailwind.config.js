module.exports = {
  content: ["./Components/**/*.{razor,html}"],
  theme: {
    extend: {
      colors: {
        cream: "#FFF8F0", tomato: "#E4572E", basil: "#3F7D58", charcoal: "#2B2B2B"
      },
      fontFamily: {
        display: ["Fraunces", "serif"], sans: ["Inter", "system-ui", "sans-serif"]
      },
      keyframes: {
        float: { "0%,100%": { transform: "translateY(0)" }, "50%": { transform: "translateY(-12px)" } },
        marquee: { "0%": { transform: "translateX(0)" }, "100%": { transform: "translateX(-50%)" } }
      },
      animation: {
        float: "float 5s ease-in-out infinite",
        "float-slow": "float 8s ease-in-out infinite",
        marquee: "marquee 30s linear infinite",
        "spin-slow": "spin 18s linear infinite"
      }
    }
  },
  plugins: []
};