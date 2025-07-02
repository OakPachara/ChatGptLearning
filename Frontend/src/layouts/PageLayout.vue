<template>
  <div class="page-layout">
    <Header />
    <div class="main-section">
      <!-- <Sidebar /> -->

      <main>
        <slot />
      </main>
    </div>
    <Footer />
  </div>
</template>

<script setup>
import Header from "../components/Header.vue";
import Sidebar from "../components/Sidebar.vue";
import Footer from "../components/Footer.vue";
</script>
