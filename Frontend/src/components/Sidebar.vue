<template>
  <nav class="flex">
    <ul>
      <li v-for="route in menuRoutes" :key="route.path">
        <RouterLink :to="route.path">
         <i :class="['mdi', route.meta?.icon]"></i>
          {{ route.meta?.title || route.name }}
        </RouterLink>
      </li>
    </ul>
  </nav>
</template>

<script setup lang="ts">
import { routes } from "../router/index"; // <-- Import your route config

// Filter out routes that should NOT show in the menu if needed (like login, 404)
const menuRoutes = routes.filter((route) => route.name);
</script>

<style scoped>
nav ul {
  list-style: none;
  padding: 0;
  display: flex;
  gap: 1rem;
}
</style>
