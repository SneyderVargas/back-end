package com.market.place.persistence.mapper;


import com.market.place.domain.UserItem;
import com.market.place.persistence.entity.User;
import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.Mappings;

@Mapper(componentModel = "spring")
public interface UserItemMapper {
    @Mappings({
            @Mapping(source = "id", target = "userId"),
            @Mapping(source = "name", target = "userName"),
            @Mapping(source = "surname", target = "userSurname")
    })
    UserItem toUsersItem(User user);
    User toUser(UserItem userItem);
}
