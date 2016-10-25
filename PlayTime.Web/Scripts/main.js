"use strict";

(function($, undefined) {

    $.PlayTime = {
        
        Init: function() {
            $.PlayTime.UI.Init();

            console.log('started');
            console.log('started2');
        },

        UI: {
            Init: function() {
                
                $('body')
                    .on('click', '[data-task-id]', function (e) {
                        $.ajax({
                            type: 'get',
                            url: 'Task/GetTaskModal',
                            data: {
                                'id': $(this).data('taskId')
                            }
                        }).success(function(data) {
                            var modal = $(data);
                            console.log(modal);

                            $('body').append(modal);
                            modal.modal('show');
                        });
                    });
            },

            Functions: {
                CreateModal: function (modalId, modalClass, headerText, bodyHtml, footerHtml, realModal) {
                    var existingModal = $('#' + modalId);
                    if (existingModal.length) {
                        existingModal.modal('hide');
                        existingModal.remove();
                    }

                    // Outmost modal
                    var modal = $('<div></div>', {
                        'id': modalId,
                        'class': 'modal',
                        'tabindex': -1,
                        'role': 'dialog',
                        'aria-labelledby': modalId,
                        'aria-hidden': false
                    });

                    // Outer dialog
                    var modalDialog = $('<div></div>', {
                        'class': 'modal-dialog ' + modalClass
                    });
                    modal.append(modalDialog);

                    // Outer content
                    var modalContent = $('<div></div>', {
                        'class': 'modal-content'
                    });
                    modalDialog.append(modalContent);

                    if (headerText) {
                        // Header
                        var modalHeader = $('<div></div>', {
                            'class': 'modal-header'
                        });
                        if (!realModal) {
                            modalHeader.append($('<button></button>', {
                                'type': 'button',
                                'class': 'close',
                                'data-dismiss': 'modal',
                                'aria-label': 'Close'
                            }));
                        }
                        modalHeader.append($('<h4></h4>', {
                            'class': 'modal-title white-text',
                            'style': 'margin:0;'
                        }).text(headerText));
                        modalContent.append(modalHeader);
                    }

                    if (bodyHtml) {
                        // Body
                        var modalBody = $('<div></div>', {
                            'class': 'modal-body'
                        }).html(bodyHtml);
                        modalContent.append(modalBody);
                    }

                    if (footerHtml) {
                        // Footer
                        var modalFooter = $('<div></div>', {
                            'class': 'modal-footer'
                        }).html(footerHtml);
                        modalContent.append(modalFooter);
                    }

                    if (realModal) {
                        modal.attr('data-keyboard', 'false');
                        modal.attr('data-backdrop', 'static');
                    }

                    $('body').append(modal);

                    // Make the modal disappear when closed.
                    modal.on('hidden.bs.modal', function () {
                        $(this).remove();
                    });

                    return modal;
                }

            }
        }
    }

    $(document).ready(function() {
        $.PlayTime.Init();
    });

})(jQuery);