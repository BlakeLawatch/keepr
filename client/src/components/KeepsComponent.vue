<template>
    <div class="selectable bg-img my-3 d-flex align-items-end justify-content-between p-2 box-shadow">
        <p class="mb-0 text-shadow text-light d-flex fs-4 fw-bold"> {{ keep.name }}</p>
        <img class="img-fluid profile" :src="keep.creator.picture" alt="" :title="keep.creator.name">
    </div>
</template>


<script>
import { computed } from 'vue';
import { Keep } from '../models/Keep';




export default {
    props: {
        keep: { type: Keep, required: true }
    },
    setup(props) {
        return {
            coverImg: computed(() => `url(${props.keep.img})`)

        }
    }
};
</script>


<style lang="scss" scoped>
.bg-img {
    background-image: v-bind(coverImg);
    background-position: center;
    background-size: cover;
    height: 30dvh;
    width: 90%;
}

.text-shadow {
    text-shadow: 1px 1px 2px rgb(3, 3, 3);
}

.box-shadow {
    box-shadow: 2px 2px 10px gray;
}
</style>