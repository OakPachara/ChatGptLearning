<template>
  <svg-icon type="mdi" :path="path"></svg-icon>
</template>


<script>
import SvgIcon from '@jamescoyle/vue-icon';
import { mdiAccount } from '@mdi/js';

export default {
	name: "web-icons-component",

	components: {
		SvgIcon
	},

	data() {
		return {
	  		path: mdiAccount,
		}
	}
}
</script>