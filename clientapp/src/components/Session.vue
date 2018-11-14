<template>
    <b-container>
        <b-row>
            <b-col>
                <b-row>
                    <b-col>Name</b-col>
                    <b-col>Date</b-col>
                </b-row>
                <b-row>
                    <b-col>Comment</b-col>
                    
                </b-row>
            </b-col>
            <b-col>Place for image</b-col>
        </b-row>
    </b-container>
</template>

<script>
export default {
    name: "Session",
    props:['Name', 'Date', 'Comment', 'ImagePath']
}
</script>

