<template>
  <div class="widget">
    <h3>{{ title }}</h3>
    <p>{{ content }}</p>
  </div>
</template>

<script setup>
defineProps(['title', 'content'])
</script>

<style scoped>
.widget {
  background: #fff;
  padding: 1rem;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}
</style>
