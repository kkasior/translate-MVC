$(function () {
    $('.FileCollection').click(function (e) {
        var ul = $(e.currentTarget).find("ul:first");

        if (ul.is(':visible'))
        {
            ul.hide(); 
        }
        else ul.show();
    })
    $('.KeysCollection').click(function (e) {
        e.stopPropagation();
        var ul = $(e.currentTarget).find("ul:first");
        
        if (ul.is(':visible'))
        { ul.hide(); }
        else ul.show();
    })
    $('.KeysCollection').dblclick(function (e) {
        e.stopPropagation();
        var englishValueText = $(e.currentTarget).find('.englishValue').text();
        var englishValueValue = $(e.currentTarget).find('.englishValue');
        var otherKeyValueText = $(e.currentTarget).find('.otherKey').text().split(" ");
        var otherKeyValue = $(e.currentTarget).find('.otherKey');
        var otherValue = $(e.currentTarget).find('.otherValue').val();
       
        
        var fullPanel = $('<div class="fullPanel"> <input type="text" value="Language:"> <input type="text" value="EN">\
                <input type="text" value="Value:"> <input type="text" value="'+ englishValueText + '"><br>\ </div>');
        for (var k = 0, klen = otherKeyValue.length; k < klen; k++) {
            for (var i = 0, len = englishValueValue.length; i < len; i++) {
                var partialPanel = $('<div class="partialPanel" style="display:none">\
                    <input type="text" value="Language:"> <input type="text" value=' + otherKeyValueText[k] + '>\
                        <input type="text" value="Value:"> <input type="text" value="' + otherValue[i] + '"><br>\
                          </div>');

                partialPanel.css("display", "block");
                fullPanel.css("display", "block1");
                $('body').append(fullPanel);
                fullPanel.append(partialPanel);


            };
        }
        fullPanel.append(' <input type="submit" value="Save" class="buttonx"> ');
         
        //var ul = $(e.currentTarget).add("div.languagePanel").css("display", "block");
       
    })
    $('.OtherLanguagesCollection').click(function (e) {
        e.stopPropagation();
        var ul = $(e.currentTarget).find("span.OtherLanguageValuesCollection").css("display", "block");
        $('.partialPanel').css("display", "none");
    })

    $('.button').click(function (e) {
        e.stopPropagation();
        var ul = $('.OtherLanguageValuesCollection').css("display", "none");
    })

    $('body').on('click','.buttonx', function (e) {
        
        $('.partialPanel').css("display", "none");
        $('.buttonx').css("display", "none");
        $('.fullPanel').css("display", "none");

    })
})
