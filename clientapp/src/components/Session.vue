<template>
    <b-container>
        <b-row>
            <b-col>
                <b-row>
                    <b-col>{{session.name}}</b-col>
                    <b-col>{{session.begintime}}</b-col>
                </b-row>
                <b-row>
                    <b-col>{{session.comment}}</b-col>
                    
                </b-row>
            </b-col>
            <b-col>Place for image</b-col>
        </b-row>
    </b-container>
</template>

<script>
export default {
    name: "Session",
    props:['session']
}
</script>

