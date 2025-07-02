<template>

    <h2>Dashboard</h2>
    <div class="widgets">
      <Widget title="Users" content="1,204 active users" />
      <Widget title="Sales" content="$19,300 this month" />
      <Widget title="Performance" content="All systems operational" />
    </div>

</template>

<script setup>
import PageLayout from '../layouts/PageLayout.vue'
import Widget from '../components/Widget.vue'
</script>

<style scoped>
.widgets {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 1rem;
}
</style>
