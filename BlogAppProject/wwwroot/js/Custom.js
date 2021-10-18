let index = 0;
function AddTag() {
    var tagEntry = document.getElementById("TagEntry");
    //Use search function to help detect an error state 
    let searchResult = search(tagEntry.value);
    if (searchResult != null) {
        //Trigger sweet alert for the empty string for whatever condition
        //is contained in the search Result var
        Swal.fire({
            title: 'Error!',
            text: 'Do you want to continue',
            icon: 'error',
            confirmButtonText:'Cool'
        })
    }
    else {
        //Create a new select option
        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index ==] = newOption;
    }






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
//The search function will detect either an empty or duplicate Tag
//Return an error string if an error is detected 
function search(str) {
    if (str == '') {
        return 'Empty tags are not permitted';
    }
    var tagsEl = document.getElementById('TagList');
    if (tagsEl) {
        let options = tagsEl.options;
        for (let index = 0; index < options.length; index++) {
            if (options(index).value == str)
                return `The tag #${str} was detected as duplicate and not permitted`
        }
    }
}