let index = 0;
function AddTag() {
    var tagEntry = document.getElementById("TagEntry");
    //Create a new select option
    let newOption = new Option(tagEntry.value, tagEntry.value);
    document.getElementById("TagList").options[index++] = newOption;
    //Clear out the TagEntry control
    tagEntry.value = "";
    return true;
}
function DeleteTag() { 
    let tagCount = 1;
    
    while (tagCount > 0) {
        let tagList = document.getElementById("TagList");
        let selectedIndex = tagList.selectedIndex;
        if (selectedIndex >= 0) {
            tagList.options[selectedIndex] = null;
            --tagCount;
        }
        else
            tagCount = 0;
        index--;
    }


}

$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
})

//Look for the tagvalues variable to see if it as data 

if (tagValues != '') {
    let tagArray = tagValues.split(",");
    for (let loop = 0; loop < tagArray.length; loop++) {
        //Load up or replace the options that we have
        ReplaceTag(tagArray[loop], loop);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}